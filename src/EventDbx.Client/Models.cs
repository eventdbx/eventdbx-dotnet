using System.Text.Json;

namespace EventDbx;

public sealed class EventDbxClientOptions
{
    public string Host { get; init; } = "127.0.0.1";
    public int Port { get; init; } = 6363;
    public string Token { get; init; } = "";
    public string TenantId { get; init; } = "default";
    public ushort ProtocolVersion { get; init; } = 1;
    public TimeSpan ConnectTimeout { get; init; } = TimeSpan.FromSeconds(5);
    public TimeSpan? RequestTimeout { get; init; } = TimeSpan.FromSeconds(10);
    public bool UseNoise { get; init; } = true;
    public bool Verbose { get; init; } = true;
    public RetryOptions Retry { get; init; } = new();
}

public sealed record RetryOptions(int Attempts = 1, int InitialDelayMs = 100, int MaxDelayMs = 1000);

public sealed record PublishTarget(string Plugin, string? Mode = null, string? Priority = null);

public sealed record AggregateSortOption(AggregateSortField Field, bool Descending = false);

public enum AggregateSortField
{
    AggregateType,
    AggregateId,
    Archived,
    CreatedAt,
    UpdatedAt,
}

public sealed class ListAggregatesOptions
{
    public string? Cursor { get; init; }
    public ulong? Take { get; init; }
    public string? Filter { get; init; }
    public string? SortText { get; init; }
    public IReadOnlyList<AggregateSortOption>? Sort { get; init; }
    public bool? IncludeArchived { get; init; }
    public bool? ArchivedOnly { get; init; }
    public string? Token { get; init; }
}

public sealed record ListAggregatesResult(string AggregatesJson, string? NextCursor, bool HasNextCursor);

public sealed class ListEventsOptions
{
    public string? Cursor { get; init; }
    public ulong? Take { get; init; }
    public string? Filter { get; init; }
    public string? Token { get; init; }
}

public sealed record ListEventsResult(string EventsJson, string? NextCursor, bool HasNextCursor);

public sealed record GetAggregateResult(bool Found, string? AggregateJson);

public sealed class SelectAggregateParams
{
    public required string AggregateType { get; init; }
    public required string AggregateId { get; init; }
    public required IReadOnlyList<string> Fields { get; init; }
    public string? Token { get; init; }
}

public sealed record SelectAggregateResult(bool Found, string? SelectionJson);

public sealed class AppendEventParams
{
    public required string AggregateType { get; init; }
    public required string AggregateId { get; init; }
    public required string EventType { get; init; }
    public required object Payload { get; init; }
    public string? Note { get; init; }
    public object? Metadata { get; init; }
    public IReadOnlyList<PublishTarget>? PublishTargets { get; init; }
    public string? Token { get; init; }
}

public sealed class PatchEventParams
{
    public required string AggregateType { get; init; }
    public required string AggregateId { get; init; }
    public required string EventType { get; init; }
    public required object Patch { get; init; }
    public string? Note { get; init; }
    public object? Metadata { get; init; }
    public IReadOnlyList<PublishTarget>? PublishTargets { get; init; }
    public string? Token { get; init; }
}

public sealed class CreateAggregateParams
{
    public required string AggregateType { get; init; }
    public required string AggregateId { get; init; }
    public required string EventType { get; init; }
    public required object Payload { get; init; }
    public string? Note { get; init; }
    public object? Metadata { get; init; }
    public IReadOnlyList<PublishTarget>? PublishTargets { get; init; }
    public string? Token { get; init; }
}

public sealed class SetArchiveParams
{
    public required string AggregateType { get; init; }
    public required string AggregateId { get; init; }
    public bool Archived { get; init; }
    public string? Note { get; init; }
    public string? Token { get; init; }
}

public sealed record VerifyAggregateResult(string MerkleRoot);

public sealed class CreateSnapshotParams
{
    public required string AggregateType { get; init; }
    public required string AggregateId { get; init; }
    public string? Comment { get; init; }
    public string? Token { get; init; }
}

public sealed class ListSnapshotsOptions
{
    public string? AggregateType { get; init; }
    public string? AggregateId { get; init; }
    public ulong? Version { get; init; }
    public string? Token { get; init; }
}

public sealed record ListSnapshotsResult(string SnapshotsJson);

public sealed class GetSnapshotParams
{
    public required ulong SnapshotId { get; init; }
    public string? Token { get; init; }
}

public sealed record GetSnapshotResult(bool Found, string? SnapshotJson);

public sealed record TenantAssignResult(bool Changed, string ShardId);

public sealed record TenantQuotaResult(bool Changed, ulong? QuotaMb, bool HasQuota);

public sealed record TenantSchemaPublishResult(string VersionId, bool Activated, bool Skipped);

public sealed class ReplaceSchemasParams
{
    public required object Schemas { get; init; }
    public string? Token { get; init; }
}

public sealed class TenantAssignParams
{
    public required string TenantId { get; init; }
    public required string ShardId { get; init; }
    public string? Token { get; init; }
}

public sealed class TenantUnassignParams
{
    public required string TenantId { get; init; }
    public string? Token { get; init; }
}

public sealed class TenantQuotaSetParams
{
    public required string TenantId { get; init; }
    public required ulong MaxStorageMb { get; init; }
    public string? Token { get; init; }
}

public sealed class TenantQuotaClearParams
{
    public required string TenantId { get; init; }
    public string? Token { get; init; }
}

public sealed class TenantQuotaRecalcParams
{
    public required string TenantId { get; init; }
    public string? Token { get; init; }
}

public sealed class TenantReloadParams
{
    public required string TenantId { get; init; }
    public string? Token { get; init; }
}

public sealed class TenantSchemaPublishParams
{
    public required string TenantId { get; init; }
    public string? Reason { get; init; }
    public string? Actor { get; init; }
    public IReadOnlyList<string>? Labels { get; init; }
    public bool Activate { get; init; }
    public bool Force { get; init; }
    public bool Reload { get; init; }
    public string? Token { get; init; }
}
