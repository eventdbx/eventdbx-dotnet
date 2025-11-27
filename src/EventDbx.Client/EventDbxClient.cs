using System.Buffers;
using System.Buffers.Binary;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Capnp;
using CapnpGen;
using Noise;

namespace EventDbx;

public sealed class EventDbxClient : IAsyncDisposable
{
    private const int MaxFrameBytes = 16 * 1024 * 1024;
    private static readonly byte[] NoisePrologue = Encoding.ASCII.GetBytes("eventdbx-control");

    private readonly EventDbxClientOptions _options;
    private TcpClient _tcpClient;
    private NetworkStream _stream;
    private Noise.Transport? _noiseTransport;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private long _requestId;
    private bool _disposed;

    private EventDbxClient(EventDbxClientOptions options, TcpClient tcpClient, NetworkStream stream)
    {
        _options = options;
        _tcpClient = tcpClient;
        _stream = stream;
    }

    public static async Task<EventDbxClient> ConnectAsync(EventDbxClientOptions options, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(options.Token))
        {
            throw new ArgumentException("Token must be provided", nameof(options));
        }

        var client = new TcpClient { NoDelay = true };
        using var connectCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        if (options.ConnectTimeout > TimeSpan.Zero)
        {
            connectCts.CancelAfter(options.ConnectTimeout);
        }

        await client.ConnectAsync(options.Host, options.Port, connectCts.Token).ConfigureAwait(false);
        var stream = client.GetStream();

        var instance = new EventDbxClient(options, client, stream);
        try
        {
            await instance.PerformHandshakeAsync(cancellationToken).ConfigureAwait(false);
            return instance;
        }
        catch
        {
            await instance.DisposeAsync().ConfigureAwait(false);
            throw;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        _noiseTransport?.Dispose();
        _gate.Dispose();
        _stream.Dispose();
        _tcpClient.Dispose();
        await Task.CompletedTask;
    }

    public async Task<ListAggregatesResult> ListAggregatesAsync(ListAggregatesOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListAggregatesOptions();
        return await InvokeAsync(
            () =>
            {
                var sortText = EncodeSort(options);
                var request = new CapnpGen.ListAggregatesRequest
                {
                    Cursor = options.Cursor ?? string.Empty,
                    HasCursor = options.Cursor != null,
                    Take = options.Take ?? 0,
                    HasTake = options.Take.HasValue,
                    Filter = options.Filter ?? string.Empty,
                    HasFilter = options.Filter != null,
                    Sort = sortText ?? string.Empty,
                    HasSort = sortText != null,
                    IncludeArchived = options.IncludeArchived ?? false,
                    ArchivedOnly = options.ArchivedOnly ?? false,
                    Token = ResolveToken(options.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.ListAggregates,
                    ListAggregates = request,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.ListAggregates)
                {
                    throw new EventDbxConnectionException("Unexpected response for listAggregates");
                }

                var resp = payload.ListAggregates;
                var next = resp.HasNextCursor ? resp.NextCursor : null;
                return new ListAggregatesResult(resp.AggregatesJson, next, resp.HasNextCursor);
            },
            cancellationToken);
    }

    public async Task<ListEventsResult> ListEventsAsync(string aggregateType, string aggregateId, ListEventsOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(aggregateType) || string.IsNullOrWhiteSpace(aggregateId))
        {
            throw new ArgumentException("Aggregate type and id must be provided");
        }

        options ??= new ListEventsOptions();
        return await InvokeAsync(
            () =>
            {
                var request = new CapnpGen.ListEventsRequest
                {
                    AggregateType = aggregateType,
                    AggregateId = aggregateId,
                    Cursor = options.Cursor ?? string.Empty,
                    HasCursor = options.Cursor != null,
                    Take = options.Take ?? 0,
                    HasTake = options.Take.HasValue,
                    Filter = options.Filter ?? string.Empty,
                    HasFilter = options.Filter != null,
                    Token = ResolveToken(options.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.ListEvents,
                    ListEvents = request,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.ListEvents)
                {
                    throw new EventDbxConnectionException("Unexpected response for listEvents");
                }

                var resp = payload.ListEvents;
                var next = resp.HasNextCursor ? resp.NextCursor : null;
                return new ListEventsResult(resp.EventsJson, next, resp.HasNextCursor);
            },
            cancellationToken);
    }

    public async Task<GetAggregateResult> GetAggregateAsync(string aggregateType, string aggregateId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(aggregateType) || string.IsNullOrWhiteSpace(aggregateId))
        {
            throw new ArgumentException("Aggregate type and id must be provided");
        }

        return await InvokeAsync(
            () =>
            {
                var request = new CapnpGen.GetAggregateRequest
                {
                    AggregateType = aggregateType,
                    AggregateId = aggregateId,
                    Token = ResolveToken(null),
                };
                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.GetAggregate,
                    GetAggregate = request,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.GetAggregate)
                {
                    throw new EventDbxConnectionException("Unexpected response for getAggregate");
                }

                var resp = payload.GetAggregate;
                var aggregate = resp.Found ? resp.AggregateJson : null;
                return new GetAggregateResult(resp.Found, aggregate);
            },
            cancellationToken);
    }

    public async Task<SelectAggregateResult> SelectAggregateAsync(SelectAggregateParams select, CancellationToken cancellationToken = default)
    {
        if (select is null)
        {
            throw new ArgumentNullException(nameof(select));
        }
        if (select.Fields.Count == 0)
        {
            throw new ArgumentException("At least one field must be specified", nameof(select));
        }

        return await InvokeAsync(
            () =>
            {
                var request = new CapnpGen.SelectAggregateRequest
                {
                    AggregateType = select.AggregateType,
                    AggregateId = select.AggregateId,
                    Token = ResolveToken(select.Token),
                    Fields = select.Fields,
                };
                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.SelectAggregate,
                    SelectAggregate = request,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.SelectAggregate)
                {
                    throw new EventDbxConnectionException("Unexpected response for selectAggregate");
                }

                var resp = payload.SelectAggregate;
                var selection = resp.Found ? resp.SelectionJson : null;
                return new SelectAggregateResult(resp.Found, selection);
            },
            cancellationToken);
    }

    public async Task<string> AppendEventAsync(AppendEventParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () => BuildAppendPayload(request, CapnpGen.ControlRequest.payload.WHICH.AppendEvent),
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.AppendEvent)
                {
                    throw new EventDbxConnectionException("Unexpected response for appendEvent");
                }

                return payload.AppendEvent.EventJson;
            },
            cancellationToken);
    }

    public async Task<string> PatchEventAsync(PatchEventParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var publishTargets = NormalizePublishTargets(request.PublishTargets);
                var inner = new CapnpGen.PatchEventRequest
                {
                    AggregateType = request.AggregateType,
                    AggregateId = request.AggregateId,
                    EventType = request.EventType,
                    PatchJson = EncodeJson(request.Patch),
                    Note = request.Note ?? string.Empty,
                    HasNote = request.Note != null,
                    MetadataJson = EncodeOptionalJson(request.Metadata) ?? string.Empty,
                    HasMetadata = request.Metadata != null,
                    PublishTargets = publishTargets,
                    HasPublishTargets = publishTargets.Count > 0,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.PatchEvent,
                    PatchEvent = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.AppendEvent)
                {
                    throw new EventDbxConnectionException("Unexpected response for patchEvent");
                }

                return payload.AppendEvent.EventJson;
            },
            cancellationToken);
    }

    public async Task<string> CreateAggregateAsync(CreateAggregateParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var publishTargets = NormalizePublishTargets(request.PublishTargets);
                var inner = new CapnpGen.CreateAggregateRequest
                {
                    AggregateType = request.AggregateType,
                    AggregateId = request.AggregateId,
                    EventType = request.EventType,
                    PayloadJson = EncodeJson(request.Payload),
                    Note = request.Note ?? string.Empty,
                    HasNote = request.Note != null,
                    MetadataJson = EncodeOptionalJson(request.Metadata) ?? string.Empty,
                    HasMetadata = request.Metadata != null,
                    PublishTargets = publishTargets,
                    HasPublishTargets = publishTargets.Count > 0,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.CreateAggregate,
                    CreateAggregate = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.CreateAggregate)
                {
                    throw new EventDbxConnectionException("Unexpected response for createAggregate");
                }
                return payload.CreateAggregate.AggregateJson;
            },
            cancellationToken);
    }

    public async Task<string> SetArchiveAsync(SetArchiveParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.SetAggregateArchiveRequest
                {
                    AggregateType = request.AggregateType,
                    AggregateId = request.AggregateId,
                    Archived = request.Archived,
                    Note = request.Note ?? string.Empty,
                    HasNote = request.Note != null,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.SetAggregateArchive,
                    SetAggregateArchive = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.SetAggregateArchive)
                {
                    throw new EventDbxConnectionException("Unexpected response for setAggregateArchive");
                }
                return payload.SetAggregateArchive.AggregateJson;
            },
            cancellationToken);
    }

    public async Task<VerifyAggregateResult> VerifyAggregateAsync(string aggregateType, string aggregateId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(aggregateType) || string.IsNullOrWhiteSpace(aggregateId))
        {
            throw new ArgumentException("Aggregate type and id must be provided");
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.VerifyAggregateRequest
                {
                    AggregateType = aggregateType,
                    AggregateId = aggregateId,
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.VerifyAggregate,
                    VerifyAggregate = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.VerifyAggregate)
                {
                    throw new EventDbxConnectionException("Unexpected response for verifyAggregate");
                }

                return new VerifyAggregateResult(payload.VerifyAggregate.MerkleRoot);
            },
            cancellationToken);
    }

    public async Task<string> CreateSnapshotAsync(CreateSnapshotParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.CreateSnapshotRequest
                {
                    AggregateType = request.AggregateType,
                    AggregateId = request.AggregateId,
                    Comment = request.Comment ?? string.Empty,
                    HasComment = request.Comment != null,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.CreateSnapshot,
                    CreateSnapshot = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.CreateSnapshot)
                {
                    throw new EventDbxConnectionException("Unexpected response for createSnapshot");
                }

                return payload.CreateSnapshot.SnapshotJson;
            },
            cancellationToken);
    }

    public async Task<ListSnapshotsResult> ListSnapshotsAsync(ListSnapshotsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListSnapshotsOptions();
        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.ListSnapshotsRequest
                {
                    AggregateType = options.AggregateType ?? string.Empty,
                    HasAggregateType = options.AggregateType != null,
                    AggregateId = options.AggregateId ?? string.Empty,
                    HasAggregateId = options.AggregateId != null,
                    Version = options.Version ?? 0,
                    HasVersion = options.Version.HasValue,
                    Token = ResolveToken(options.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.ListSnapshots,
                    ListSnapshots = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.ListSnapshots)
                {
                    throw new EventDbxConnectionException("Unexpected response for listSnapshots");
                }

                return new ListSnapshotsResult(payload.ListSnapshots.SnapshotsJson);
            },
            cancellationToken);
    }

    public async Task<GetSnapshotResult> GetSnapshotAsync(GetSnapshotParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.GetSnapshotRequest
                {
                    SnapshotId = request.SnapshotId,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.GetSnapshot,
                    GetSnapshot = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.GetSnapshot)
                {
                    throw new EventDbxConnectionException("Unexpected response for getSnapshot");
                }

                var resp = payload.GetSnapshot;
                var snapshot = resp.Found ? resp.SnapshotJson : null;
                return new GetSnapshotResult(resp.Found, snapshot);
            },
            cancellationToken);
    }

    public async Task<string> ListSchemasAsync(string? tokenOverride = null, CancellationToken cancellationToken = default)
    {
        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.ListSchemasRequest
                {
                    Token = ResolveToken(tokenOverride),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.ListSchemas,
                    ListSchemas = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.ListSchemas)
                {
                    throw new EventDbxConnectionException("Unexpected response for listSchemas");
                }
                return payload.ListSchemas.SchemasJson;
            },
            cancellationToken);
    }

    public async Task<uint> ReplaceSchemasAsync(ReplaceSchemasParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.ReplaceSchemasRequest
                {
                    Token = ResolveToken(request.Token),
                    SchemasJson = EncodeJson(request.Schemas),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.ReplaceSchemas,
                    ReplaceSchemas = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.ReplaceSchemas)
                {
                    throw new EventDbxConnectionException("Unexpected response for replaceSchemas");
                }
                return payload.ReplaceSchemas.Replaced;
            },
            cancellationToken);
    }

    public async Task<TenantAssignResult> TenantAssignAsync(TenantAssignParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.TenantAssignRequest
                {
                    TenantId = request.TenantId,
                    ShardId = request.ShardId,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.TenantAssign,
                    TenantAssign = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.TenantAssign)
                {
                    throw new EventDbxConnectionException("Unexpected response for tenantAssign");
                }
                var resp = payload.TenantAssign;
                return new TenantAssignResult(resp.Changed, resp.ShardId);
            },
            cancellationToken);
    }

    public async Task<bool> TenantUnassignAsync(TenantUnassignParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.TenantUnassignRequest
                {
                    TenantId = request.TenantId,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.TenantUnassign,
                    TenantUnassign = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.TenantUnassign)
                {
                    throw new EventDbxConnectionException("Unexpected response for tenantUnassign");
                }
                return payload.TenantUnassign.Changed;
            },
            cancellationToken);
    }

    public async Task<TenantQuotaResult> TenantQuotaSetAsync(TenantQuotaSetParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.TenantQuotaSetRequest
                {
                    TenantId = request.TenantId,
                    MaxStorageMb = request.MaxStorageMb,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.TenantQuotaSet,
                    TenantQuotaSet = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.TenantQuotaSet)
                {
                    throw new EventDbxConnectionException("Unexpected response for tenantQuotaSet");
                }
                var resp = payload.TenantQuotaSet;
                var quota = resp.HasQuota ? resp.QuotaMb : (ulong?)null;
                return new TenantQuotaResult(resp.Changed, quota, resp.HasQuota);
            },
            cancellationToken);
    }

    public async Task<bool> TenantQuotaClearAsync(TenantQuotaClearParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.TenantQuotaClearRequest
                {
                    TenantId = request.TenantId,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.TenantQuotaClear,
                    TenantQuotaClear = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.TenantQuotaClear)
                {
                    throw new EventDbxConnectionException("Unexpected response for tenantQuotaClear");
                }
                return payload.TenantQuotaClear.Changed;
            },
            cancellationToken);
    }

    public async Task<ulong> TenantQuotaRecalcAsync(TenantQuotaRecalcParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.TenantQuotaRecalcRequest
                {
                    TenantId = request.TenantId,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.TenantQuotaRecalc,
                    TenantQuotaRecalc = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.TenantQuotaRecalc)
                {
                    throw new EventDbxConnectionException("Unexpected response for tenantQuotaRecalc");
                }
                return payload.TenantQuotaRecalc.StorageBytes;
            },
            cancellationToken);
    }

    public async Task<bool> TenantReloadAsync(TenantReloadParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var inner = new CapnpGen.TenantReloadRequest
                {
                    TenantId = request.TenantId,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.TenantReload,
                    TenantReload = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.TenantReload)
                {
                    throw new EventDbxConnectionException("Unexpected response for tenantReload");
                }
                return payload.TenantReload.Reloaded;
            },
            cancellationToken);
    }

    public async Task<TenantSchemaPublishResult> TenantSchemaPublishAsync(TenantSchemaPublishParams request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return await InvokeAsync(
            () =>
            {
                var labels = request.Labels ?? Array.Empty<string>();
                var inner = new CapnpGen.TenantSchemaPublishRequest
                {
                    TenantId = request.TenantId,
                    Reason = request.Reason ?? string.Empty,
                    HasReason = request.Reason != null,
                    Actor = request.Actor ?? string.Empty,
                    HasActor = request.Actor != null,
                    Labels = labels,
                    Activate = request.Activate,
                    Force = request.Force,
                    Reload = request.Reload,
                    Token = ResolveToken(request.Token),
                };

                return new CapnpGen.ControlRequest.payload
                {
                    which = CapnpGen.ControlRequest.payload.WHICH.TenantSchemaPublish,
                    TenantSchemaPublish = inner,
                };
            },
            payload =>
            {
                if (payload.which != CapnpGen.ControlResponse.payload.WHICH.TenantSchemaPublish)
                {
                    throw new EventDbxConnectionException("Unexpected response for tenantSchemaPublish");
                }
                var resp = payload.TenantSchemaPublish;
                return new TenantSchemaPublishResult(resp.VersionId, resp.Activated, resp.Skipped);
            },
            cancellationToken);
    }

    private async Task PerformHandshakeAsync(CancellationToken cancellationToken)
    {
        var hello = new CapnpGen.ControlHello
        {
            ProtocolVersion = _options.ProtocolVersion,
            Token = _options.Token,
            TenantId = _options.TenantId,
            NoNoise = !_options.UseNoise,
        };

        var helloBytes = CapnpCodec.Serialize<CapnpGen.ControlHello.WRITER>(hello);
        await _stream.WriteAsync(helloBytes.AsMemory(), cancellationToken).ConfigureAwait(false);
        await _stream.FlushAsync(cancellationToken).ConfigureAwait(false);

        var responseFrame = await CapnpCodec.ReadFrameFromStreamAsync(_stream, cancellationToken).ConfigureAwait(false);
        var responseState = DeserializerState.CreateRoot(responseFrame);
        var response = CapnpSerializable.Create<CapnpGen.ControlHelloResponse>(responseState)
                       ?? throw new EventDbxHandshakeException("Handshake response was empty");

        if (!response.Accepted)
        {
            throw new EventDbxHandshakeException(response.Message ?? "Handshake rejected");
        }

        var noiseRequested = _options.UseNoise && !response.NoNoise;
        if (noiseRequested)
        {
            _noiseTransport = await PerformNoiseHandshakeAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    private async Task<Noise.Transport> PerformNoiseHandshakeAsync(CancellationToken cancellationToken)
    {
        var protocol = new Protocol(HandshakePattern.NN, PatternModifiers.Psk0);
        var psk = DerivePsk(_options.Token);
        var state = protocol.Create(
            initiator: true,
            prologue: NoisePrologue,
            psks: new[] { psk });

        var buffer = ArrayPool<byte>.Shared.Rent(Protocol.MaxMessageLength);
        try
        {
            var (written, _, _) = state.WriteMessage(ReadOnlySpan<byte>.Empty, buffer);
            await WriteLengthPrefixedAsync(buffer.AsMemory(0, written), cancellationToken).ConfigureAwait(false);

            var serverFrame = await ReadLengthPrefixedAsync(cancellationToken).ConfigureAwait(false);
            var (_, _, transport) = state.ReadMessage(serverFrame, buffer);
            if (transport is null)
            {
                throw new EventDbxHandshakeException("Noise transport was not established");
            }
            return transport;
        }
        finally
        {
            state.Dispose();
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private async Task<T> InvokeAsync<T>(
        Func<CapnpGen.ControlRequest.payload> payloadFactory,
        Func<CapnpGen.ControlResponse.payload, T> parse,
        CancellationToken cancellationToken)
    {
        EnsureNotDisposed();
        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            using var cts = CreateRequestCts(cancellationToken);
            var requestId = (ulong)Interlocked.Increment(ref _requestId);
            var payload = payloadFactory();
            var request = new CapnpGen.ControlRequest
            {
                Id = requestId,
                Payload = payload,
            };

            var payloadBytes = CapnpCodec.Serialize<CapnpGen.ControlRequest.WRITER>(request);
            await SendFrameAsync(payloadBytes, cts.Token).ConfigureAwait(false);

            var responseBytes = await ReadFrameAsync(cts.Token).ConfigureAwait(false);
            var frame = CapnpCodec.DeserializeFrame(responseBytes);
            var responseState = DeserializerState.CreateRoot(frame);
            var response = CapnpSerializable.Create<CapnpGen.ControlResponse>(responseState)
                           ?? throw new EventDbxConnectionException("Received empty response");

            if (response.Id != requestId)
            {
                throw new EventDbxConnectionException($"Mismatched response id {response.Id}, expected {requestId}");
            }

            var reader = response.Payload ?? throw new EventDbxConnectionException("Response payload was empty");
            if (reader.which == CapnpGen.ControlResponse.payload.WHICH.Error)
            {
                var err = reader.Error;
                throw new EventDbxApiException(err.Code, err.Message);
            }

            return parse(reader);
        }
        catch (IOException ex)
        {
            throw new EventDbxConnectionException("IO failure while communicating with server", ex);
        }
        finally
        {
            _gate.Release();
        }
    }

    private async Task SendFrameAsync(byte[] payload, CancellationToken cancellationToken)
    {
        if (payload.Length > MaxFrameBytes)
        {
            throw new EventDbxException($"Frame exceeds maximum allowed size ({MaxFrameBytes} bytes)");
        }

        if (_noiseTransport is null)
        {
            await WriteLengthPrefixedAsync(payload, cancellationToken).ConfigureAwait(false);
            return;
        }

        var buffer = ArrayPool<byte>.Shared.Rent(payload.Length + 32);
        try
        {
            var written = _noiseTransport.WriteMessage(payload, buffer);
            await WriteLengthPrefixedAsync(buffer.AsMemory(0, written), cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private async Task<byte[]> ReadFrameAsync(CancellationToken cancellationToken)
    {
        var cipher = await ReadLengthPrefixedAsync(cancellationToken).ConfigureAwait(false);
        if (_noiseTransport is null)
        {
            return cipher;
        }

        var buffer = ArrayPool<byte>.Shared.Rent(cipher.Length);
        try
        {
            var len = _noiseTransport.ReadMessage(cipher, buffer);
            return buffer.AsSpan(0, len).ToArray();
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private async Task<byte[]> ReadLengthPrefixedAsync(CancellationToken cancellationToken)
    {
        var header = new byte[4];
        await ReadExactAsync(header, cancellationToken).ConfigureAwait(false);
        var length = BinaryPrimitives.ReadUInt32BigEndian(header);
        if (length > MaxFrameBytes + 1024)
        {
            throw new EventDbxException($"Frame length {length} exceeds limit");
        }

        var buffer = new byte[length];
        if (length > 0)
        {
            await ReadExactAsync(buffer, cancellationToken).ConfigureAwait(false);
        }
        return buffer;
    }

    private async Task WriteLengthPrefixedAsync(ReadOnlyMemory<byte> payload, CancellationToken cancellationToken)
    {
        var header = new byte[4];
        BinaryPrimitives.WriteUInt32BigEndian(header, (uint)payload.Length);
        await _stream.WriteAsync(header.AsMemory(), cancellationToken).ConfigureAwait(false);
        if (!payload.IsEmpty)
        {
            await _stream.WriteAsync(payload, cancellationToken).ConfigureAwait(false);
        }
        await _stream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task ReadExactAsync(byte[] buffer, CancellationToken cancellationToken)
    {
        var remaining = buffer.Length;
        var offset = 0;
        while (remaining > 0)
        {
            var read = await _stream.ReadAsync(buffer.AsMemory(offset, remaining), cancellationToken).ConfigureAwait(false);
            if (read == 0)
            {
                throw new IOException("Connection closed by peer");
            }
            offset += read;
            remaining -= read;
        }
    }

    private CancellationTokenSource CreateRequestCts(CancellationToken cancellationToken)
    {
        if (_options.RequestTimeout is { } timeout && timeout > TimeSpan.Zero)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(timeout);
            return cts;
        }

        return CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    }

    private static string EncodeJson(object value)
    {
        return value switch
        {
            string raw => raw,
            JsonElement element => element.GetRawText(),
            JsonDocument document => document.RootElement.GetRawText(),
            _ => JsonSerializer.Serialize(value),
        };
    }

    private static string? EncodeOptionalJson(object? value)
    {
        return value is null ? null : EncodeJson(value);
    }

    private List<CapnpGen.PublishTarget> NormalizePublishTargets(IReadOnlyList<PublishTarget>? targets)
    {
        if (targets is null || targets.Count == 0)
        {
            return new List<CapnpGen.PublishTarget>();
        }

        var list = new List<CapnpGen.PublishTarget>(targets.Count);
        foreach (var target in targets)
        {
            list.Add(new CapnpGen.PublishTarget
            {
                Plugin = target.Plugin,
                Mode = target.Mode ?? string.Empty,
                HasMode = target.Mode != null,
                Priority = target.Priority ?? string.Empty,
                HasPriority = target.Priority != null,
            });
        }
        return list;
    }

    private CapnpGen.ControlRequest.payload BuildAppendPayload(AppendEventParams request, CapnpGen.ControlRequest.payload.WHICH which)
    {
        var publishTargets = NormalizePublishTargets(request.PublishTargets);
        var inner = new CapnpGen.AppendEventRequest
        {
            AggregateType = request.AggregateType,
            AggregateId = request.AggregateId,
            EventType = request.EventType,
            PayloadJson = EncodeJson(request.Payload),
            Note = request.Note ?? string.Empty,
            HasNote = request.Note != null,
            MetadataJson = EncodeOptionalJson(request.Metadata) ?? string.Empty,
            HasMetadata = request.Metadata != null,
            PublishTargets = publishTargets,
            HasPublishTargets = publishTargets.Count > 0,
            Token = ResolveToken(request.Token),
        };

        return new CapnpGen.ControlRequest.payload
        {
            which = which,
            AppendEvent = inner,
        };
    }

    private string ResolveToken(string? overrideToken)
    {
        return string.IsNullOrWhiteSpace(overrideToken) ? _options.Token : overrideToken!;
    }

    private static string? EncodeSort(ListAggregatesOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.SortText))
        {
            var trimmed = options.SortText.Trim();
            return string.IsNullOrWhiteSpace(trimmed) ? null : trimmed;
        }

        if (options.Sort is null || options.Sort.Count == 0)
        {
            return null;
        }

        var parts = new List<string>(options.Sort.Count);
        foreach (var sort in options.Sort)
        {
            var field = sort.Field switch
            {
                AggregateSortField.AggregateType => "aggregate_type",
                AggregateSortField.AggregateId => "aggregate_id",
                AggregateSortField.Archived => "archived",
                AggregateSortField.CreatedAt => "created_at",
                AggregateSortField.UpdatedAt => "updated_at",
                _ => "created_at",
            };
            var order = sort.Descending ? "desc" : "asc";
            parts.Add($"{field}:{order}");
        }

        return parts.Count == 0 ? null : string.Join(", ", parts);
    }

    private static byte[] DerivePsk(string token)
    {
        using var sha = SHA256.Create();
        return sha.ComputeHash(Encoding.UTF8.GetBytes(token));
    }

    private void EnsureNotDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(EventDbxClient));
        }
    }
}
