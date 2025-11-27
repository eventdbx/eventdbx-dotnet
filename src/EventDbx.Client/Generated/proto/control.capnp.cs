using Capnp;
using Capnp.Rpc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CapnpGen
{
    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8fda33e4e41726e4UL)]
    public class ControlRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8fda33e4e41726e4UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Id = reader.Id;
            Payload = CapnpSerializable.Create<CapnpGen.ControlRequest.payload>(reader.Payload);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Id = Id;
            Payload?.serialize(writer.Payload);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong Id
        {
            get;
            set;
        }

        public CapnpGen.ControlRequest.payload Payload
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public ulong Id => ctx.ReadDataULong(0UL, 0UL);
            public payload.READER Payload => new payload.READER(ctx);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 1);
            }

            public ulong Id
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public payload.WRITER Payload
            {
                get => Rewrap<payload.WRITER>();
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc7e4a16f84e5e821UL)]
        public class payload : ICapnpSerializable
        {
            public const UInt64 typeId = 0xc7e4a16f84e5e821UL;
            public enum WHICH : ushort
            {
                ListAggregates = 0,
                GetAggregate = 1,
                ListEvents = 2,
                AppendEvent = 3,
                VerifyAggregate = 4,
                PatchEvent = 5,
                SelectAggregate = 6,
                CreateAggregate = 7,
                SetAggregateArchive = 8,
                ListSchemas = 9,
                ReplaceSchemas = 10,
                TenantAssign = 11,
                TenantUnassign = 12,
                TenantQuotaSet = 13,
                TenantQuotaClear = 14,
                TenantQuotaRecalc = 15,
                TenantReload = 16,
                TenantSchemaPublish = 17,
                CreateSnapshot = 18,
                ListSnapshots = 19,
                GetSnapshot = 20,
                undefined = 65535
            }

            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                switch (reader.which)
                {
                    case WHICH.ListAggregates:
                        ListAggregates = CapnpSerializable.Create<CapnpGen.ListAggregatesRequest>(reader.ListAggregates);
                        break;
                    case WHICH.GetAggregate:
                        GetAggregate = CapnpSerializable.Create<CapnpGen.GetAggregateRequest>(reader.GetAggregate);
                        break;
                    case WHICH.ListEvents:
                        ListEvents = CapnpSerializable.Create<CapnpGen.ListEventsRequest>(reader.ListEvents);
                        break;
                    case WHICH.AppendEvent:
                        AppendEvent = CapnpSerializable.Create<CapnpGen.AppendEventRequest>(reader.AppendEvent);
                        break;
                    case WHICH.VerifyAggregate:
                        VerifyAggregate = CapnpSerializable.Create<CapnpGen.VerifyAggregateRequest>(reader.VerifyAggregate);
                        break;
                    case WHICH.PatchEvent:
                        PatchEvent = CapnpSerializable.Create<CapnpGen.PatchEventRequest>(reader.PatchEvent);
                        break;
                    case WHICH.SelectAggregate:
                        SelectAggregate = CapnpSerializable.Create<CapnpGen.SelectAggregateRequest>(reader.SelectAggregate);
                        break;
                    case WHICH.CreateAggregate:
                        CreateAggregate = CapnpSerializable.Create<CapnpGen.CreateAggregateRequest>(reader.CreateAggregate);
                        break;
                    case WHICH.SetAggregateArchive:
                        SetAggregateArchive = CapnpSerializable.Create<CapnpGen.SetAggregateArchiveRequest>(reader.SetAggregateArchive);
                        break;
                    case WHICH.ListSchemas:
                        ListSchemas = CapnpSerializable.Create<CapnpGen.ListSchemasRequest>(reader.ListSchemas);
                        break;
                    case WHICH.ReplaceSchemas:
                        ReplaceSchemas = CapnpSerializable.Create<CapnpGen.ReplaceSchemasRequest>(reader.ReplaceSchemas);
                        break;
                    case WHICH.TenantAssign:
                        TenantAssign = CapnpSerializable.Create<CapnpGen.TenantAssignRequest>(reader.TenantAssign);
                        break;
                    case WHICH.TenantUnassign:
                        TenantUnassign = CapnpSerializable.Create<CapnpGen.TenantUnassignRequest>(reader.TenantUnassign);
                        break;
                    case WHICH.TenantQuotaSet:
                        TenantQuotaSet = CapnpSerializable.Create<CapnpGen.TenantQuotaSetRequest>(reader.TenantQuotaSet);
                        break;
                    case WHICH.TenantQuotaClear:
                        TenantQuotaClear = CapnpSerializable.Create<CapnpGen.TenantQuotaClearRequest>(reader.TenantQuotaClear);
                        break;
                    case WHICH.TenantQuotaRecalc:
                        TenantQuotaRecalc = CapnpSerializable.Create<CapnpGen.TenantQuotaRecalcRequest>(reader.TenantQuotaRecalc);
                        break;
                    case WHICH.TenantReload:
                        TenantReload = CapnpSerializable.Create<CapnpGen.TenantReloadRequest>(reader.TenantReload);
                        break;
                    case WHICH.TenantSchemaPublish:
                        TenantSchemaPublish = CapnpSerializable.Create<CapnpGen.TenantSchemaPublishRequest>(reader.TenantSchemaPublish);
                        break;
                    case WHICH.CreateSnapshot:
                        CreateSnapshot = CapnpSerializable.Create<CapnpGen.CreateSnapshotRequest>(reader.CreateSnapshot);
                        break;
                    case WHICH.ListSnapshots:
                        ListSnapshots = CapnpSerializable.Create<CapnpGen.ListSnapshotsRequest>(reader.ListSnapshots);
                        break;
                    case WHICH.GetSnapshot:
                        GetSnapshot = CapnpSerializable.Create<CapnpGen.GetSnapshotRequest>(reader.GetSnapshot);
                        break;
                }

                applyDefaults();
            }

            private WHICH _which = WHICH.undefined;
            private object _content;
            public WHICH which
            {
                get => _which;
                set
                {
                    if (value == _which)
                        return;
                    _which = value;
                    switch (value)
                    {
                        case WHICH.ListAggregates:
                            _content = null;
                            break;
                        case WHICH.GetAggregate:
                            _content = null;
                            break;
                        case WHICH.ListEvents:
                            _content = null;
                            break;
                        case WHICH.AppendEvent:
                            _content = null;
                            break;
                        case WHICH.VerifyAggregate:
                            _content = null;
                            break;
                        case WHICH.PatchEvent:
                            _content = null;
                            break;
                        case WHICH.SelectAggregate:
                            _content = null;
                            break;
                        case WHICH.CreateAggregate:
                            _content = null;
                            break;
                        case WHICH.SetAggregateArchive:
                            _content = null;
                            break;
                        case WHICH.ListSchemas:
                            _content = null;
                            break;
                        case WHICH.ReplaceSchemas:
                            _content = null;
                            break;
                        case WHICH.TenantAssign:
                            _content = null;
                            break;
                        case WHICH.TenantUnassign:
                            _content = null;
                            break;
                        case WHICH.TenantQuotaSet:
                            _content = null;
                            break;
                        case WHICH.TenantQuotaClear:
                            _content = null;
                            break;
                        case WHICH.TenantQuotaRecalc:
                            _content = null;
                            break;
                        case WHICH.TenantReload:
                            _content = null;
                            break;
                        case WHICH.TenantSchemaPublish:
                            _content = null;
                            break;
                        case WHICH.CreateSnapshot:
                            _content = null;
                            break;
                        case WHICH.ListSnapshots:
                            _content = null;
                            break;
                        case WHICH.GetSnapshot:
                            _content = null;
                            break;
                    }
                }
            }

            public void serialize(WRITER writer)
            {
                writer.which = which;
                switch (which)
                {
                    case WHICH.ListAggregates:
                        ListAggregates?.serialize(writer.ListAggregates);
                        break;
                    case WHICH.GetAggregate:
                        GetAggregate?.serialize(writer.GetAggregate);
                        break;
                    case WHICH.ListEvents:
                        ListEvents?.serialize(writer.ListEvents);
                        break;
                    case WHICH.AppendEvent:
                        AppendEvent?.serialize(writer.AppendEvent);
                        break;
                    case WHICH.VerifyAggregate:
                        VerifyAggregate?.serialize(writer.VerifyAggregate);
                        break;
                    case WHICH.PatchEvent:
                        PatchEvent?.serialize(writer.PatchEvent);
                        break;
                    case WHICH.SelectAggregate:
                        SelectAggregate?.serialize(writer.SelectAggregate);
                        break;
                    case WHICH.CreateAggregate:
                        CreateAggregate?.serialize(writer.CreateAggregate);
                        break;
                    case WHICH.SetAggregateArchive:
                        SetAggregateArchive?.serialize(writer.SetAggregateArchive);
                        break;
                    case WHICH.ListSchemas:
                        ListSchemas?.serialize(writer.ListSchemas);
                        break;
                    case WHICH.ReplaceSchemas:
                        ReplaceSchemas?.serialize(writer.ReplaceSchemas);
                        break;
                    case WHICH.TenantAssign:
                        TenantAssign?.serialize(writer.TenantAssign);
                        break;
                    case WHICH.TenantUnassign:
                        TenantUnassign?.serialize(writer.TenantUnassign);
                        break;
                    case WHICH.TenantQuotaSet:
                        TenantQuotaSet?.serialize(writer.TenantQuotaSet);
                        break;
                    case WHICH.TenantQuotaClear:
                        TenantQuotaClear?.serialize(writer.TenantQuotaClear);
                        break;
                    case WHICH.TenantQuotaRecalc:
                        TenantQuotaRecalc?.serialize(writer.TenantQuotaRecalc);
                        break;
                    case WHICH.TenantReload:
                        TenantReload?.serialize(writer.TenantReload);
                        break;
                    case WHICH.TenantSchemaPublish:
                        TenantSchemaPublish?.serialize(writer.TenantSchemaPublish);
                        break;
                    case WHICH.CreateSnapshot:
                        CreateSnapshot?.serialize(writer.CreateSnapshot);
                        break;
                    case WHICH.ListSnapshots:
                        ListSnapshots?.serialize(writer.ListSnapshots);
                        break;
                    case WHICH.GetSnapshot:
                        GetSnapshot?.serialize(writer.GetSnapshot);
                        break;
                }
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public CapnpGen.ListAggregatesRequest ListAggregates
            {
                get => _which == WHICH.ListAggregates ? (CapnpGen.ListAggregatesRequest)_content : null;
                set
                {
                    _which = WHICH.ListAggregates;
                    _content = value;
                }
            }

            public CapnpGen.GetAggregateRequest GetAggregate
            {
                get => _which == WHICH.GetAggregate ? (CapnpGen.GetAggregateRequest)_content : null;
                set
                {
                    _which = WHICH.GetAggregate;
                    _content = value;
                }
            }

            public CapnpGen.ListEventsRequest ListEvents
            {
                get => _which == WHICH.ListEvents ? (CapnpGen.ListEventsRequest)_content : null;
                set
                {
                    _which = WHICH.ListEvents;
                    _content = value;
                }
            }

            public CapnpGen.AppendEventRequest AppendEvent
            {
                get => _which == WHICH.AppendEvent ? (CapnpGen.AppendEventRequest)_content : null;
                set
                {
                    _which = WHICH.AppendEvent;
                    _content = value;
                }
            }

            public CapnpGen.VerifyAggregateRequest VerifyAggregate
            {
                get => _which == WHICH.VerifyAggregate ? (CapnpGen.VerifyAggregateRequest)_content : null;
                set
                {
                    _which = WHICH.VerifyAggregate;
                    _content = value;
                }
            }

            public CapnpGen.PatchEventRequest PatchEvent
            {
                get => _which == WHICH.PatchEvent ? (CapnpGen.PatchEventRequest)_content : null;
                set
                {
                    _which = WHICH.PatchEvent;
                    _content = value;
                }
            }

            public CapnpGen.SelectAggregateRequest SelectAggregate
            {
                get => _which == WHICH.SelectAggregate ? (CapnpGen.SelectAggregateRequest)_content : null;
                set
                {
                    _which = WHICH.SelectAggregate;
                    _content = value;
                }
            }

            public CapnpGen.CreateAggregateRequest CreateAggregate
            {
                get => _which == WHICH.CreateAggregate ? (CapnpGen.CreateAggregateRequest)_content : null;
                set
                {
                    _which = WHICH.CreateAggregate;
                    _content = value;
                }
            }

            public CapnpGen.SetAggregateArchiveRequest SetAggregateArchive
            {
                get => _which == WHICH.SetAggregateArchive ? (CapnpGen.SetAggregateArchiveRequest)_content : null;
                set
                {
                    _which = WHICH.SetAggregateArchive;
                    _content = value;
                }
            }

            public CapnpGen.ListSchemasRequest ListSchemas
            {
                get => _which == WHICH.ListSchemas ? (CapnpGen.ListSchemasRequest)_content : null;
                set
                {
                    _which = WHICH.ListSchemas;
                    _content = value;
                }
            }

            public CapnpGen.ReplaceSchemasRequest ReplaceSchemas
            {
                get => _which == WHICH.ReplaceSchemas ? (CapnpGen.ReplaceSchemasRequest)_content : null;
                set
                {
                    _which = WHICH.ReplaceSchemas;
                    _content = value;
                }
            }

            public CapnpGen.TenantAssignRequest TenantAssign
            {
                get => _which == WHICH.TenantAssign ? (CapnpGen.TenantAssignRequest)_content : null;
                set
                {
                    _which = WHICH.TenantAssign;
                    _content = value;
                }
            }

            public CapnpGen.TenantUnassignRequest TenantUnassign
            {
                get => _which == WHICH.TenantUnassign ? (CapnpGen.TenantUnassignRequest)_content : null;
                set
                {
                    _which = WHICH.TenantUnassign;
                    _content = value;
                }
            }

            public CapnpGen.TenantQuotaSetRequest TenantQuotaSet
            {
                get => _which == WHICH.TenantQuotaSet ? (CapnpGen.TenantQuotaSetRequest)_content : null;
                set
                {
                    _which = WHICH.TenantQuotaSet;
                    _content = value;
                }
            }

            public CapnpGen.TenantQuotaClearRequest TenantQuotaClear
            {
                get => _which == WHICH.TenantQuotaClear ? (CapnpGen.TenantQuotaClearRequest)_content : null;
                set
                {
                    _which = WHICH.TenantQuotaClear;
                    _content = value;
                }
            }

            public CapnpGen.TenantQuotaRecalcRequest TenantQuotaRecalc
            {
                get => _which == WHICH.TenantQuotaRecalc ? (CapnpGen.TenantQuotaRecalcRequest)_content : null;
                set
                {
                    _which = WHICH.TenantQuotaRecalc;
                    _content = value;
                }
            }

            public CapnpGen.TenantReloadRequest TenantReload
            {
                get => _which == WHICH.TenantReload ? (CapnpGen.TenantReloadRequest)_content : null;
                set
                {
                    _which = WHICH.TenantReload;
                    _content = value;
                }
            }

            public CapnpGen.TenantSchemaPublishRequest TenantSchemaPublish
            {
                get => _which == WHICH.TenantSchemaPublish ? (CapnpGen.TenantSchemaPublishRequest)_content : null;
                set
                {
                    _which = WHICH.TenantSchemaPublish;
                    _content = value;
                }
            }

            public CapnpGen.CreateSnapshotRequest CreateSnapshot
            {
                get => _which == WHICH.CreateSnapshot ? (CapnpGen.CreateSnapshotRequest)_content : null;
                set
                {
                    _which = WHICH.CreateSnapshot;
                    _content = value;
                }
            }

            public CapnpGen.ListSnapshotsRequest ListSnapshots
            {
                get => _which == WHICH.ListSnapshots ? (CapnpGen.ListSnapshotsRequest)_content : null;
                set
                {
                    _which = WHICH.ListSnapshots;
                    _content = value;
                }
            }

            public CapnpGen.GetSnapshotRequest GetSnapshot
            {
                get => _which == WHICH.GetSnapshot ? (CapnpGen.GetSnapshotRequest)_content : null;
                set
                {
                    _which = WHICH.GetSnapshot;
                    _content = value;
                }
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public WHICH which => (WHICH)ctx.ReadDataUShort(64U, (ushort)0);
                public CapnpGen.ListAggregatesRequest.READER ListAggregates => which == WHICH.ListAggregates ? ctx.ReadStruct(0, CapnpGen.ListAggregatesRequest.READER.create) : default;
                public CapnpGen.GetAggregateRequest.READER GetAggregate => which == WHICH.GetAggregate ? ctx.ReadStruct(0, CapnpGen.GetAggregateRequest.READER.create) : default;
                public CapnpGen.ListEventsRequest.READER ListEvents => which == WHICH.ListEvents ? ctx.ReadStruct(0, CapnpGen.ListEventsRequest.READER.create) : default;
                public CapnpGen.AppendEventRequest.READER AppendEvent => which == WHICH.AppendEvent ? ctx.ReadStruct(0, CapnpGen.AppendEventRequest.READER.create) : default;
                public CapnpGen.VerifyAggregateRequest.READER VerifyAggregate => which == WHICH.VerifyAggregate ? ctx.ReadStruct(0, CapnpGen.VerifyAggregateRequest.READER.create) : default;
                public CapnpGen.PatchEventRequest.READER PatchEvent => which == WHICH.PatchEvent ? ctx.ReadStruct(0, CapnpGen.PatchEventRequest.READER.create) : default;
                public CapnpGen.SelectAggregateRequest.READER SelectAggregate => which == WHICH.SelectAggregate ? ctx.ReadStruct(0, CapnpGen.SelectAggregateRequest.READER.create) : default;
                public CapnpGen.CreateAggregateRequest.READER CreateAggregate => which == WHICH.CreateAggregate ? ctx.ReadStruct(0, CapnpGen.CreateAggregateRequest.READER.create) : default;
                public CapnpGen.SetAggregateArchiveRequest.READER SetAggregateArchive => which == WHICH.SetAggregateArchive ? ctx.ReadStruct(0, CapnpGen.SetAggregateArchiveRequest.READER.create) : default;
                public CapnpGen.ListSchemasRequest.READER ListSchemas => which == WHICH.ListSchemas ? ctx.ReadStruct(0, CapnpGen.ListSchemasRequest.READER.create) : default;
                public CapnpGen.ReplaceSchemasRequest.READER ReplaceSchemas => which == WHICH.ReplaceSchemas ? ctx.ReadStruct(0, CapnpGen.ReplaceSchemasRequest.READER.create) : default;
                public CapnpGen.TenantAssignRequest.READER TenantAssign => which == WHICH.TenantAssign ? ctx.ReadStruct(0, CapnpGen.TenantAssignRequest.READER.create) : default;
                public CapnpGen.TenantUnassignRequest.READER TenantUnassign => which == WHICH.TenantUnassign ? ctx.ReadStruct(0, CapnpGen.TenantUnassignRequest.READER.create) : default;
                public CapnpGen.TenantQuotaSetRequest.READER TenantQuotaSet => which == WHICH.TenantQuotaSet ? ctx.ReadStruct(0, CapnpGen.TenantQuotaSetRequest.READER.create) : default;
                public CapnpGen.TenantQuotaClearRequest.READER TenantQuotaClear => which == WHICH.TenantQuotaClear ? ctx.ReadStruct(0, CapnpGen.TenantQuotaClearRequest.READER.create) : default;
                public CapnpGen.TenantQuotaRecalcRequest.READER TenantQuotaRecalc => which == WHICH.TenantQuotaRecalc ? ctx.ReadStruct(0, CapnpGen.TenantQuotaRecalcRequest.READER.create) : default;
                public CapnpGen.TenantReloadRequest.READER TenantReload => which == WHICH.TenantReload ? ctx.ReadStruct(0, CapnpGen.TenantReloadRequest.READER.create) : default;
                public CapnpGen.TenantSchemaPublishRequest.READER TenantSchemaPublish => which == WHICH.TenantSchemaPublish ? ctx.ReadStruct(0, CapnpGen.TenantSchemaPublishRequest.READER.create) : default;
                public CapnpGen.CreateSnapshotRequest.READER CreateSnapshot => which == WHICH.CreateSnapshot ? ctx.ReadStruct(0, CapnpGen.CreateSnapshotRequest.READER.create) : default;
                public CapnpGen.ListSnapshotsRequest.READER ListSnapshots => which == WHICH.ListSnapshots ? ctx.ReadStruct(0, CapnpGen.ListSnapshotsRequest.READER.create) : default;
                public CapnpGen.GetSnapshotRequest.READER GetSnapshot => which == WHICH.GetSnapshot ? ctx.ReadStruct(0, CapnpGen.GetSnapshotRequest.READER.create) : default;
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                }

                public WHICH which
                {
                    get => (WHICH)this.ReadDataUShort(64U, (ushort)0);
                    set => this.WriteData(64U, (ushort)value, (ushort)0);
                }

                public CapnpGen.ListAggregatesRequest.WRITER ListAggregates
                {
                    get => which == WHICH.ListAggregates ? BuildPointer<CapnpGen.ListAggregatesRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.GetAggregateRequest.WRITER GetAggregate
                {
                    get => which == WHICH.GetAggregate ? BuildPointer<CapnpGen.GetAggregateRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ListEventsRequest.WRITER ListEvents
                {
                    get => which == WHICH.ListEvents ? BuildPointer<CapnpGen.ListEventsRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.AppendEventRequest.WRITER AppendEvent
                {
                    get => which == WHICH.AppendEvent ? BuildPointer<CapnpGen.AppendEventRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.VerifyAggregateRequest.WRITER VerifyAggregate
                {
                    get => which == WHICH.VerifyAggregate ? BuildPointer<CapnpGen.VerifyAggregateRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.PatchEventRequest.WRITER PatchEvent
                {
                    get => which == WHICH.PatchEvent ? BuildPointer<CapnpGen.PatchEventRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.SelectAggregateRequest.WRITER SelectAggregate
                {
                    get => which == WHICH.SelectAggregate ? BuildPointer<CapnpGen.SelectAggregateRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.CreateAggregateRequest.WRITER CreateAggregate
                {
                    get => which == WHICH.CreateAggregate ? BuildPointer<CapnpGen.CreateAggregateRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.SetAggregateArchiveRequest.WRITER SetAggregateArchive
                {
                    get => which == WHICH.SetAggregateArchive ? BuildPointer<CapnpGen.SetAggregateArchiveRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ListSchemasRequest.WRITER ListSchemas
                {
                    get => which == WHICH.ListSchemas ? BuildPointer<CapnpGen.ListSchemasRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ReplaceSchemasRequest.WRITER ReplaceSchemas
                {
                    get => which == WHICH.ReplaceSchemas ? BuildPointer<CapnpGen.ReplaceSchemasRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantAssignRequest.WRITER TenantAssign
                {
                    get => which == WHICH.TenantAssign ? BuildPointer<CapnpGen.TenantAssignRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantUnassignRequest.WRITER TenantUnassign
                {
                    get => which == WHICH.TenantUnassign ? BuildPointer<CapnpGen.TenantUnassignRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantQuotaSetRequest.WRITER TenantQuotaSet
                {
                    get => which == WHICH.TenantQuotaSet ? BuildPointer<CapnpGen.TenantQuotaSetRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantQuotaClearRequest.WRITER TenantQuotaClear
                {
                    get => which == WHICH.TenantQuotaClear ? BuildPointer<CapnpGen.TenantQuotaClearRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantQuotaRecalcRequest.WRITER TenantQuotaRecalc
                {
                    get => which == WHICH.TenantQuotaRecalc ? BuildPointer<CapnpGen.TenantQuotaRecalcRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantReloadRequest.WRITER TenantReload
                {
                    get => which == WHICH.TenantReload ? BuildPointer<CapnpGen.TenantReloadRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantSchemaPublishRequest.WRITER TenantSchemaPublish
                {
                    get => which == WHICH.TenantSchemaPublish ? BuildPointer<CapnpGen.TenantSchemaPublishRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.CreateSnapshotRequest.WRITER CreateSnapshot
                {
                    get => which == WHICH.CreateSnapshot ? BuildPointer<CapnpGen.CreateSnapshotRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ListSnapshotsRequest.WRITER ListSnapshots
                {
                    get => which == WHICH.ListSnapshots ? BuildPointer<CapnpGen.ListSnapshotsRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.GetSnapshotRequest.WRITER GetSnapshot
                {
                    get => which == WHICH.GetSnapshot ? BuildPointer<CapnpGen.GetSnapshotRequest.WRITER>(0) : default;
                    set => Link(0, value);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd14cbb921913e882UL)]
    public class ControlResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd14cbb921913e882UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Id = reader.Id;
            Payload = CapnpSerializable.Create<CapnpGen.ControlResponse.payload>(reader.Payload);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Id = Id;
            Payload?.serialize(writer.Payload);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong Id
        {
            get;
            set;
        }

        public CapnpGen.ControlResponse.payload Payload
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public ulong Id => ctx.ReadDataULong(0UL, 0UL);
            public payload.READER Payload => new payload.READER(ctx);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 1);
            }

            public ulong Id
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public payload.WRITER Payload
            {
                get => Rewrap<payload.WRITER>();
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb3cab97742c109e4UL)]
        public class payload : ICapnpSerializable
        {
            public const UInt64 typeId = 0xb3cab97742c109e4UL;
            public enum WHICH : ushort
            {
                ListAggregates = 0,
                GetAggregate = 1,
                ListEvents = 2,
                AppendEvent = 3,
                VerifyAggregate = 4,
                SelectAggregate = 5,
                Error = 6,
                CreateAggregate = 7,
                SetAggregateArchive = 8,
                ListSchemas = 9,
                ReplaceSchemas = 10,
                TenantAssign = 11,
                TenantUnassign = 12,
                TenantQuotaSet = 13,
                TenantQuotaClear = 14,
                TenantQuotaRecalc = 15,
                TenantReload = 16,
                TenantSchemaPublish = 17,
                CreateSnapshot = 18,
                ListSnapshots = 19,
                GetSnapshot = 20,
                undefined = 65535
            }

            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                switch (reader.which)
                {
                    case WHICH.ListAggregates:
                        ListAggregates = CapnpSerializable.Create<CapnpGen.ListAggregatesResponse>(reader.ListAggregates);
                        break;
                    case WHICH.GetAggregate:
                        GetAggregate = CapnpSerializable.Create<CapnpGen.GetAggregateResponse>(reader.GetAggregate);
                        break;
                    case WHICH.ListEvents:
                        ListEvents = CapnpSerializable.Create<CapnpGen.ListEventsResponse>(reader.ListEvents);
                        break;
                    case WHICH.AppendEvent:
                        AppendEvent = CapnpSerializable.Create<CapnpGen.AppendEventResponse>(reader.AppendEvent);
                        break;
                    case WHICH.VerifyAggregate:
                        VerifyAggregate = CapnpSerializable.Create<CapnpGen.VerifyAggregateResponse>(reader.VerifyAggregate);
                        break;
                    case WHICH.SelectAggregate:
                        SelectAggregate = CapnpSerializable.Create<CapnpGen.SelectAggregateResponse>(reader.SelectAggregate);
                        break;
                    case WHICH.Error:
                        Error = CapnpSerializable.Create<CapnpGen.ControlError>(reader.Error);
                        break;
                    case WHICH.CreateAggregate:
                        CreateAggregate = CapnpSerializable.Create<CapnpGen.CreateAggregateResponse>(reader.CreateAggregate);
                        break;
                    case WHICH.SetAggregateArchive:
                        SetAggregateArchive = CapnpSerializable.Create<CapnpGen.SetAggregateArchiveResponse>(reader.SetAggregateArchive);
                        break;
                    case WHICH.ListSchemas:
                        ListSchemas = CapnpSerializable.Create<CapnpGen.ListSchemasResponse>(reader.ListSchemas);
                        break;
                    case WHICH.ReplaceSchemas:
                        ReplaceSchemas = CapnpSerializable.Create<CapnpGen.ReplaceSchemasResponse>(reader.ReplaceSchemas);
                        break;
                    case WHICH.TenantAssign:
                        TenantAssign = CapnpSerializable.Create<CapnpGen.TenantAssignResponse>(reader.TenantAssign);
                        break;
                    case WHICH.TenantUnassign:
                        TenantUnassign = CapnpSerializable.Create<CapnpGen.TenantUnassignResponse>(reader.TenantUnassign);
                        break;
                    case WHICH.TenantQuotaSet:
                        TenantQuotaSet = CapnpSerializable.Create<CapnpGen.TenantQuotaSetResponse>(reader.TenantQuotaSet);
                        break;
                    case WHICH.TenantQuotaClear:
                        TenantQuotaClear = CapnpSerializable.Create<CapnpGen.TenantQuotaClearResponse>(reader.TenantQuotaClear);
                        break;
                    case WHICH.TenantQuotaRecalc:
                        TenantQuotaRecalc = CapnpSerializable.Create<CapnpGen.TenantQuotaRecalcResponse>(reader.TenantQuotaRecalc);
                        break;
                    case WHICH.TenantReload:
                        TenantReload = CapnpSerializable.Create<CapnpGen.TenantReloadResponse>(reader.TenantReload);
                        break;
                    case WHICH.TenantSchemaPublish:
                        TenantSchemaPublish = CapnpSerializable.Create<CapnpGen.TenantSchemaPublishResponse>(reader.TenantSchemaPublish);
                        break;
                    case WHICH.CreateSnapshot:
                        CreateSnapshot = CapnpSerializable.Create<CapnpGen.CreateSnapshotResponse>(reader.CreateSnapshot);
                        break;
                    case WHICH.ListSnapshots:
                        ListSnapshots = CapnpSerializable.Create<CapnpGen.ListSnapshotsResponse>(reader.ListSnapshots);
                        break;
                    case WHICH.GetSnapshot:
                        GetSnapshot = CapnpSerializable.Create<CapnpGen.GetSnapshotResponse>(reader.GetSnapshot);
                        break;
                }

                applyDefaults();
            }

            private WHICH _which = WHICH.undefined;
            private object _content;
            public WHICH which
            {
                get => _which;
                set
                {
                    if (value == _which)
                        return;
                    _which = value;
                    switch (value)
                    {
                        case WHICH.ListAggregates:
                            _content = null;
                            break;
                        case WHICH.GetAggregate:
                            _content = null;
                            break;
                        case WHICH.ListEvents:
                            _content = null;
                            break;
                        case WHICH.AppendEvent:
                            _content = null;
                            break;
                        case WHICH.VerifyAggregate:
                            _content = null;
                            break;
                        case WHICH.SelectAggregate:
                            _content = null;
                            break;
                        case WHICH.Error:
                            _content = null;
                            break;
                        case WHICH.CreateAggregate:
                            _content = null;
                            break;
                        case WHICH.SetAggregateArchive:
                            _content = null;
                            break;
                        case WHICH.ListSchemas:
                            _content = null;
                            break;
                        case WHICH.ReplaceSchemas:
                            _content = null;
                            break;
                        case WHICH.TenantAssign:
                            _content = null;
                            break;
                        case WHICH.TenantUnassign:
                            _content = null;
                            break;
                        case WHICH.TenantQuotaSet:
                            _content = null;
                            break;
                        case WHICH.TenantQuotaClear:
                            _content = null;
                            break;
                        case WHICH.TenantQuotaRecalc:
                            _content = null;
                            break;
                        case WHICH.TenantReload:
                            _content = null;
                            break;
                        case WHICH.TenantSchemaPublish:
                            _content = null;
                            break;
                        case WHICH.CreateSnapshot:
                            _content = null;
                            break;
                        case WHICH.ListSnapshots:
                            _content = null;
                            break;
                        case WHICH.GetSnapshot:
                            _content = null;
                            break;
                    }
                }
            }

            public void serialize(WRITER writer)
            {
                writer.which = which;
                switch (which)
                {
                    case WHICH.ListAggregates:
                        ListAggregates?.serialize(writer.ListAggregates);
                        break;
                    case WHICH.GetAggregate:
                        GetAggregate?.serialize(writer.GetAggregate);
                        break;
                    case WHICH.ListEvents:
                        ListEvents?.serialize(writer.ListEvents);
                        break;
                    case WHICH.AppendEvent:
                        AppendEvent?.serialize(writer.AppendEvent);
                        break;
                    case WHICH.VerifyAggregate:
                        VerifyAggregate?.serialize(writer.VerifyAggregate);
                        break;
                    case WHICH.SelectAggregate:
                        SelectAggregate?.serialize(writer.SelectAggregate);
                        break;
                    case WHICH.Error:
                        Error?.serialize(writer.Error);
                        break;
                    case WHICH.CreateAggregate:
                        CreateAggregate?.serialize(writer.CreateAggregate);
                        break;
                    case WHICH.SetAggregateArchive:
                        SetAggregateArchive?.serialize(writer.SetAggregateArchive);
                        break;
                    case WHICH.ListSchemas:
                        ListSchemas?.serialize(writer.ListSchemas);
                        break;
                    case WHICH.ReplaceSchemas:
                        ReplaceSchemas?.serialize(writer.ReplaceSchemas);
                        break;
                    case WHICH.TenantAssign:
                        TenantAssign?.serialize(writer.TenantAssign);
                        break;
                    case WHICH.TenantUnassign:
                        TenantUnassign?.serialize(writer.TenantUnassign);
                        break;
                    case WHICH.TenantQuotaSet:
                        TenantQuotaSet?.serialize(writer.TenantQuotaSet);
                        break;
                    case WHICH.TenantQuotaClear:
                        TenantQuotaClear?.serialize(writer.TenantQuotaClear);
                        break;
                    case WHICH.TenantQuotaRecalc:
                        TenantQuotaRecalc?.serialize(writer.TenantQuotaRecalc);
                        break;
                    case WHICH.TenantReload:
                        TenantReload?.serialize(writer.TenantReload);
                        break;
                    case WHICH.TenantSchemaPublish:
                        TenantSchemaPublish?.serialize(writer.TenantSchemaPublish);
                        break;
                    case WHICH.CreateSnapshot:
                        CreateSnapshot?.serialize(writer.CreateSnapshot);
                        break;
                    case WHICH.ListSnapshots:
                        ListSnapshots?.serialize(writer.ListSnapshots);
                        break;
                    case WHICH.GetSnapshot:
                        GetSnapshot?.serialize(writer.GetSnapshot);
                        break;
                }
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public CapnpGen.ListAggregatesResponse ListAggregates
            {
                get => _which == WHICH.ListAggregates ? (CapnpGen.ListAggregatesResponse)_content : null;
                set
                {
                    _which = WHICH.ListAggregates;
                    _content = value;
                }
            }

            public CapnpGen.GetAggregateResponse GetAggregate
            {
                get => _which == WHICH.GetAggregate ? (CapnpGen.GetAggregateResponse)_content : null;
                set
                {
                    _which = WHICH.GetAggregate;
                    _content = value;
                }
            }

            public CapnpGen.ListEventsResponse ListEvents
            {
                get => _which == WHICH.ListEvents ? (CapnpGen.ListEventsResponse)_content : null;
                set
                {
                    _which = WHICH.ListEvents;
                    _content = value;
                }
            }

            public CapnpGen.AppendEventResponse AppendEvent
            {
                get => _which == WHICH.AppendEvent ? (CapnpGen.AppendEventResponse)_content : null;
                set
                {
                    _which = WHICH.AppendEvent;
                    _content = value;
                }
            }

            public CapnpGen.VerifyAggregateResponse VerifyAggregate
            {
                get => _which == WHICH.VerifyAggregate ? (CapnpGen.VerifyAggregateResponse)_content : null;
                set
                {
                    _which = WHICH.VerifyAggregate;
                    _content = value;
                }
            }

            public CapnpGen.SelectAggregateResponse SelectAggregate
            {
                get => _which == WHICH.SelectAggregate ? (CapnpGen.SelectAggregateResponse)_content : null;
                set
                {
                    _which = WHICH.SelectAggregate;
                    _content = value;
                }
            }

            public CapnpGen.ControlError Error
            {
                get => _which == WHICH.Error ? (CapnpGen.ControlError)_content : null;
                set
                {
                    _which = WHICH.Error;
                    _content = value;
                }
            }

            public CapnpGen.CreateAggregateResponse CreateAggregate
            {
                get => _which == WHICH.CreateAggregate ? (CapnpGen.CreateAggregateResponse)_content : null;
                set
                {
                    _which = WHICH.CreateAggregate;
                    _content = value;
                }
            }

            public CapnpGen.SetAggregateArchiveResponse SetAggregateArchive
            {
                get => _which == WHICH.SetAggregateArchive ? (CapnpGen.SetAggregateArchiveResponse)_content : null;
                set
                {
                    _which = WHICH.SetAggregateArchive;
                    _content = value;
                }
            }

            public CapnpGen.ListSchemasResponse ListSchemas
            {
                get => _which == WHICH.ListSchemas ? (CapnpGen.ListSchemasResponse)_content : null;
                set
                {
                    _which = WHICH.ListSchemas;
                    _content = value;
                }
            }

            public CapnpGen.ReplaceSchemasResponse ReplaceSchemas
            {
                get => _which == WHICH.ReplaceSchemas ? (CapnpGen.ReplaceSchemasResponse)_content : null;
                set
                {
                    _which = WHICH.ReplaceSchemas;
                    _content = value;
                }
            }

            public CapnpGen.TenantAssignResponse TenantAssign
            {
                get => _which == WHICH.TenantAssign ? (CapnpGen.TenantAssignResponse)_content : null;
                set
                {
                    _which = WHICH.TenantAssign;
                    _content = value;
                }
            }

            public CapnpGen.TenantUnassignResponse TenantUnassign
            {
                get => _which == WHICH.TenantUnassign ? (CapnpGen.TenantUnassignResponse)_content : null;
                set
                {
                    _which = WHICH.TenantUnassign;
                    _content = value;
                }
            }

            public CapnpGen.TenantQuotaSetResponse TenantQuotaSet
            {
                get => _which == WHICH.TenantQuotaSet ? (CapnpGen.TenantQuotaSetResponse)_content : null;
                set
                {
                    _which = WHICH.TenantQuotaSet;
                    _content = value;
                }
            }

            public CapnpGen.TenantQuotaClearResponse TenantQuotaClear
            {
                get => _which == WHICH.TenantQuotaClear ? (CapnpGen.TenantQuotaClearResponse)_content : null;
                set
                {
                    _which = WHICH.TenantQuotaClear;
                    _content = value;
                }
            }

            public CapnpGen.TenantQuotaRecalcResponse TenantQuotaRecalc
            {
                get => _which == WHICH.TenantQuotaRecalc ? (CapnpGen.TenantQuotaRecalcResponse)_content : null;
                set
                {
                    _which = WHICH.TenantQuotaRecalc;
                    _content = value;
                }
            }

            public CapnpGen.TenantReloadResponse TenantReload
            {
                get => _which == WHICH.TenantReload ? (CapnpGen.TenantReloadResponse)_content : null;
                set
                {
                    _which = WHICH.TenantReload;
                    _content = value;
                }
            }

            public CapnpGen.TenantSchemaPublishResponse TenantSchemaPublish
            {
                get => _which == WHICH.TenantSchemaPublish ? (CapnpGen.TenantSchemaPublishResponse)_content : null;
                set
                {
                    _which = WHICH.TenantSchemaPublish;
                    _content = value;
                }
            }

            public CapnpGen.CreateSnapshotResponse CreateSnapshot
            {
                get => _which == WHICH.CreateSnapshot ? (CapnpGen.CreateSnapshotResponse)_content : null;
                set
                {
                    _which = WHICH.CreateSnapshot;
                    _content = value;
                }
            }

            public CapnpGen.ListSnapshotsResponse ListSnapshots
            {
                get => _which == WHICH.ListSnapshots ? (CapnpGen.ListSnapshotsResponse)_content : null;
                set
                {
                    _which = WHICH.ListSnapshots;
                    _content = value;
                }
            }

            public CapnpGen.GetSnapshotResponse GetSnapshot
            {
                get => _which == WHICH.GetSnapshot ? (CapnpGen.GetSnapshotResponse)_content : null;
                set
                {
                    _which = WHICH.GetSnapshot;
                    _content = value;
                }
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public WHICH which => (WHICH)ctx.ReadDataUShort(64U, (ushort)0);
                public CapnpGen.ListAggregatesResponse.READER ListAggregates => which == WHICH.ListAggregates ? ctx.ReadStruct(0, CapnpGen.ListAggregatesResponse.READER.create) : default;
                public CapnpGen.GetAggregateResponse.READER GetAggregate => which == WHICH.GetAggregate ? ctx.ReadStruct(0, CapnpGen.GetAggregateResponse.READER.create) : default;
                public CapnpGen.ListEventsResponse.READER ListEvents => which == WHICH.ListEvents ? ctx.ReadStruct(0, CapnpGen.ListEventsResponse.READER.create) : default;
                public CapnpGen.AppendEventResponse.READER AppendEvent => which == WHICH.AppendEvent ? ctx.ReadStruct(0, CapnpGen.AppendEventResponse.READER.create) : default;
                public CapnpGen.VerifyAggregateResponse.READER VerifyAggregate => which == WHICH.VerifyAggregate ? ctx.ReadStruct(0, CapnpGen.VerifyAggregateResponse.READER.create) : default;
                public CapnpGen.SelectAggregateResponse.READER SelectAggregate => which == WHICH.SelectAggregate ? ctx.ReadStruct(0, CapnpGen.SelectAggregateResponse.READER.create) : default;
                public CapnpGen.ControlError.READER Error => which == WHICH.Error ? ctx.ReadStruct(0, CapnpGen.ControlError.READER.create) : default;
                public CapnpGen.CreateAggregateResponse.READER CreateAggregate => which == WHICH.CreateAggregate ? ctx.ReadStruct(0, CapnpGen.CreateAggregateResponse.READER.create) : default;
                public CapnpGen.SetAggregateArchiveResponse.READER SetAggregateArchive => which == WHICH.SetAggregateArchive ? ctx.ReadStruct(0, CapnpGen.SetAggregateArchiveResponse.READER.create) : default;
                public CapnpGen.ListSchemasResponse.READER ListSchemas => which == WHICH.ListSchemas ? ctx.ReadStruct(0, CapnpGen.ListSchemasResponse.READER.create) : default;
                public CapnpGen.ReplaceSchemasResponse.READER ReplaceSchemas => which == WHICH.ReplaceSchemas ? ctx.ReadStruct(0, CapnpGen.ReplaceSchemasResponse.READER.create) : default;
                public CapnpGen.TenantAssignResponse.READER TenantAssign => which == WHICH.TenantAssign ? ctx.ReadStruct(0, CapnpGen.TenantAssignResponse.READER.create) : default;
                public CapnpGen.TenantUnassignResponse.READER TenantUnassign => which == WHICH.TenantUnassign ? ctx.ReadStruct(0, CapnpGen.TenantUnassignResponse.READER.create) : default;
                public CapnpGen.TenantQuotaSetResponse.READER TenantQuotaSet => which == WHICH.TenantQuotaSet ? ctx.ReadStruct(0, CapnpGen.TenantQuotaSetResponse.READER.create) : default;
                public CapnpGen.TenantQuotaClearResponse.READER TenantQuotaClear => which == WHICH.TenantQuotaClear ? ctx.ReadStruct(0, CapnpGen.TenantQuotaClearResponse.READER.create) : default;
                public CapnpGen.TenantQuotaRecalcResponse.READER TenantQuotaRecalc => which == WHICH.TenantQuotaRecalc ? ctx.ReadStruct(0, CapnpGen.TenantQuotaRecalcResponse.READER.create) : default;
                public CapnpGen.TenantReloadResponse.READER TenantReload => which == WHICH.TenantReload ? ctx.ReadStruct(0, CapnpGen.TenantReloadResponse.READER.create) : default;
                public CapnpGen.TenantSchemaPublishResponse.READER TenantSchemaPublish => which == WHICH.TenantSchemaPublish ? ctx.ReadStruct(0, CapnpGen.TenantSchemaPublishResponse.READER.create) : default;
                public CapnpGen.CreateSnapshotResponse.READER CreateSnapshot => which == WHICH.CreateSnapshot ? ctx.ReadStruct(0, CapnpGen.CreateSnapshotResponse.READER.create) : default;
                public CapnpGen.ListSnapshotsResponse.READER ListSnapshots => which == WHICH.ListSnapshots ? ctx.ReadStruct(0, CapnpGen.ListSnapshotsResponse.READER.create) : default;
                public CapnpGen.GetSnapshotResponse.READER GetSnapshot => which == WHICH.GetSnapshot ? ctx.ReadStruct(0, CapnpGen.GetSnapshotResponse.READER.create) : default;
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                }

                public WHICH which
                {
                    get => (WHICH)this.ReadDataUShort(64U, (ushort)0);
                    set => this.WriteData(64U, (ushort)value, (ushort)0);
                }

                public CapnpGen.ListAggregatesResponse.WRITER ListAggregates
                {
                    get => which == WHICH.ListAggregates ? BuildPointer<CapnpGen.ListAggregatesResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.GetAggregateResponse.WRITER GetAggregate
                {
                    get => which == WHICH.GetAggregate ? BuildPointer<CapnpGen.GetAggregateResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ListEventsResponse.WRITER ListEvents
                {
                    get => which == WHICH.ListEvents ? BuildPointer<CapnpGen.ListEventsResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.AppendEventResponse.WRITER AppendEvent
                {
                    get => which == WHICH.AppendEvent ? BuildPointer<CapnpGen.AppendEventResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.VerifyAggregateResponse.WRITER VerifyAggregate
                {
                    get => which == WHICH.VerifyAggregate ? BuildPointer<CapnpGen.VerifyAggregateResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.SelectAggregateResponse.WRITER SelectAggregate
                {
                    get => which == WHICH.SelectAggregate ? BuildPointer<CapnpGen.SelectAggregateResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ControlError.WRITER Error
                {
                    get => which == WHICH.Error ? BuildPointer<CapnpGen.ControlError.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.CreateAggregateResponse.WRITER CreateAggregate
                {
                    get => which == WHICH.CreateAggregate ? BuildPointer<CapnpGen.CreateAggregateResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.SetAggregateArchiveResponse.WRITER SetAggregateArchive
                {
                    get => which == WHICH.SetAggregateArchive ? BuildPointer<CapnpGen.SetAggregateArchiveResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ListSchemasResponse.WRITER ListSchemas
                {
                    get => which == WHICH.ListSchemas ? BuildPointer<CapnpGen.ListSchemasResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ReplaceSchemasResponse.WRITER ReplaceSchemas
                {
                    get => which == WHICH.ReplaceSchemas ? BuildPointer<CapnpGen.ReplaceSchemasResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantAssignResponse.WRITER TenantAssign
                {
                    get => which == WHICH.TenantAssign ? BuildPointer<CapnpGen.TenantAssignResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantUnassignResponse.WRITER TenantUnassign
                {
                    get => which == WHICH.TenantUnassign ? BuildPointer<CapnpGen.TenantUnassignResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantQuotaSetResponse.WRITER TenantQuotaSet
                {
                    get => which == WHICH.TenantQuotaSet ? BuildPointer<CapnpGen.TenantQuotaSetResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantQuotaClearResponse.WRITER TenantQuotaClear
                {
                    get => which == WHICH.TenantQuotaClear ? BuildPointer<CapnpGen.TenantQuotaClearResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantQuotaRecalcResponse.WRITER TenantQuotaRecalc
                {
                    get => which == WHICH.TenantQuotaRecalc ? BuildPointer<CapnpGen.TenantQuotaRecalcResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantReloadResponse.WRITER TenantReload
                {
                    get => which == WHICH.TenantReload ? BuildPointer<CapnpGen.TenantReloadResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.TenantSchemaPublishResponse.WRITER TenantSchemaPublish
                {
                    get => which == WHICH.TenantSchemaPublish ? BuildPointer<CapnpGen.TenantSchemaPublishResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.CreateSnapshotResponse.WRITER CreateSnapshot
                {
                    get => which == WHICH.CreateSnapshot ? BuildPointer<CapnpGen.CreateSnapshotResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.ListSnapshotsResponse.WRITER ListSnapshots
                {
                    get => which == WHICH.ListSnapshots ? BuildPointer<CapnpGen.ListSnapshotsResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }

                public CapnpGen.GetSnapshotResponse.WRITER GetSnapshot
                {
                    get => which == WHICH.GetSnapshot ? BuildPointer<CapnpGen.GetSnapshotResponse.WRITER>(0) : default;
                    set => Link(0, value);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x876cc8bf35b87a14UL)]
    public class ControlHello : ICapnpSerializable
    {
        public const UInt64 typeId = 0x876cc8bf35b87a14UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            ProtocolVersion = reader.ProtocolVersion;
            Token = reader.Token;
            TenantId = reader.TenantId;
            NoNoise = reader.NoNoise;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.ProtocolVersion = ProtocolVersion;
            writer.Token = Token;
            writer.TenantId = TenantId;
            writer.NoNoise = NoNoise;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ushort ProtocolVersion
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public string TenantId
        {
            get;
            set;
        }

        public bool NoNoise
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public ushort ProtocolVersion => ctx.ReadDataUShort(0UL, (ushort)0);
            public string Token => ctx.ReadText(0, null);
            public string TenantId => ctx.ReadText(1, null);
            public bool NoNoise => ctx.ReadDataBool(16UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 2);
            }

            public ushort ProtocolVersion
            {
                get => this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, value, (ushort)0);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string TenantId
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public bool NoNoise
            {
                get => this.ReadDataBool(16UL, false);
                set => this.WriteData(16UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x982ec7f176899729UL)]
    public class ControlHelloResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0x982ec7f176899729UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Accepted = reader.Accepted;
            Message = reader.Message;
            NoNoise = reader.NoNoise;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Accepted = Accepted;
            writer.Message = Message;
            writer.NoNoise = NoNoise;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Accepted
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public bool NoNoise
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public bool Accepted => ctx.ReadDataBool(0UL, false);
            public string Message => ctx.ReadText(0, null);
            public bool NoNoise => ctx.ReadDataBool(1UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public bool Accepted
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string Message
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public bool NoNoise
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8742560d77290705UL)]
    public class ListAggregatesRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8742560d77290705UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Cursor = reader.Cursor;
            HasCursor = reader.HasCursor;
            Take = reader.Take;
            HasTake = reader.HasTake;
            Filter = reader.Filter;
            HasFilter = reader.HasFilter;
            Sort = reader.Sort;
            HasSort = reader.HasSort;
            IncludeArchived = reader.IncludeArchived;
            ArchivedOnly = reader.ArchivedOnly;
            Token = reader.Token;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Cursor = Cursor;
            writer.HasCursor = HasCursor;
            writer.Take = Take;
            writer.HasTake = HasTake;
            writer.Filter = Filter;
            writer.HasFilter = HasFilter;
            writer.Sort = Sort;
            writer.HasSort = HasSort;
            writer.IncludeArchived = IncludeArchived;
            writer.ArchivedOnly = ArchivedOnly;
            writer.Token = Token;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Cursor
        {
            get;
            set;
        }

        public bool HasCursor
        {
            get;
            set;
        }

        public ulong Take
        {
            get;
            set;
        }

        public bool HasTake
        {
            get;
            set;
        }

        public string Filter
        {
            get;
            set;
        }

        public bool HasFilter
        {
            get;
            set;
        }

        public string Sort
        {
            get;
            set;
        }

        public bool HasSort
        {
            get;
            set;
        }

        public bool IncludeArchived
        {
            get;
            set;
        }

        public bool ArchivedOnly
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Cursor => ctx.ReadText(0, null);
            public bool HasCursor => ctx.ReadDataBool(0UL, false);
            public ulong Take => ctx.ReadDataULong(64UL, 0UL);
            public bool HasTake => ctx.ReadDataBool(1UL, false);
            public string Filter => ctx.ReadText(1, null);
            public bool HasFilter => ctx.ReadDataBool(2UL, false);
            public string Sort => ctx.ReadText(2, null);
            public bool HasSort => ctx.ReadDataBool(3UL, false);
            public bool IncludeArchived => ctx.ReadDataBool(4UL, false);
            public bool ArchivedOnly => ctx.ReadDataBool(5UL, false);
            public string Token => ctx.ReadText(3, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 4);
            }

            public string Cursor
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public bool HasCursor
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public ulong Take
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public bool HasTake
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public string Filter
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public bool HasFilter
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }

            public string Sort
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public bool HasSort
            {
                get => this.ReadDataBool(3UL, false);
                set => this.WriteData(3UL, value, false);
            }

            public bool IncludeArchived
            {
                get => this.ReadDataBool(4UL, false);
                set => this.WriteData(4UL, value, false);
            }

            public bool ArchivedOnly
            {
                get => this.ReadDataBool(5UL, false);
                set => this.WriteData(5UL, value, false);
            }

            public string Token
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x916909a9cf95dccaUL)]
    public class ListAggregatesResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0x916909a9cf95dccaUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            AggregatesJson = reader.AggregatesJson;
            NextCursor = reader.NextCursor;
            HasNextCursor = reader.HasNextCursor;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.AggregatesJson = AggregatesJson;
            writer.NextCursor = NextCursor;
            writer.HasNextCursor = HasNextCursor;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string AggregatesJson
        {
            get;
            set;
        }

        public string NextCursor
        {
            get;
            set;
        }

        public bool HasNextCursor
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string AggregatesJson => ctx.ReadText(0, null);
            public string NextCursor => ctx.ReadText(1, null);
            public bool HasNextCursor => ctx.ReadDataBool(0UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 2);
            }

            public string AggregatesJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string NextCursor
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public bool HasNextCursor
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc7a596ee3e26e7baUL)]
    public class GetAggregateRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc7a596ee3e26e7baUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            Token = reader.Token;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.Token = Token;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string AggregateType => ctx.ReadText(0, null);
            public string AggregateId => ctx.ReadText(1, null);
            public string Token => ctx.ReadText(2, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 3);
            }

            public string AggregateType
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string Token
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb200f7426e31ec1cUL)]
    public class GetAggregateResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xb200f7426e31ec1cUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Found = reader.Found;
            AggregateJson = reader.AggregateJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Found = Found;
            writer.AggregateJson = AggregateJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Found
        {
            get;
            set;
        }

        public string AggregateJson
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public bool Found => ctx.ReadDataBool(0UL, false);
            public string AggregateJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public bool Found
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string AggregateJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbdf285f0794fa9ffUL)]
    public class ListEventsRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xbdf285f0794fa9ffUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            Cursor = reader.Cursor;
            HasCursor = reader.HasCursor;
            Take = reader.Take;
            HasTake = reader.HasTake;
            Filter = reader.Filter;
            HasFilter = reader.HasFilter;
            Token = reader.Token;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.Cursor = Cursor;
            writer.HasCursor = HasCursor;
            writer.Take = Take;
            writer.HasTake = HasTake;
            writer.Filter = Filter;
            writer.HasFilter = HasFilter;
            writer.Token = Token;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public string Cursor
        {
            get;
            set;
        }

        public bool HasCursor
        {
            get;
            set;
        }

        public ulong Take
        {
            get;
            set;
        }

        public bool HasTake
        {
            get;
            set;
        }

        public string Filter
        {
            get;
            set;
        }

        public bool HasFilter
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string AggregateType => ctx.ReadText(0, null);
            public string AggregateId => ctx.ReadText(1, null);
            public string Cursor => ctx.ReadText(2, null);
            public bool HasCursor => ctx.ReadDataBool(0UL, false);
            public ulong Take => ctx.ReadDataULong(64UL, 0UL);
            public bool HasTake => ctx.ReadDataBool(1UL, false);
            public string Filter => ctx.ReadText(3, null);
            public bool HasFilter => ctx.ReadDataBool(2UL, false);
            public string Token => ctx.ReadText(4, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 5);
            }

            public string AggregateType
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string Cursor
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public bool HasCursor
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public ulong Take
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public bool HasTake
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public string Filter
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public bool HasFilter
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }

            public string Token
            {
                get => this.ReadText(4, null);
                set => this.WriteText(4, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc383ede64847587fUL)]
    public class ListEventsResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc383ede64847587fUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            EventsJson = reader.EventsJson;
            NextCursor = reader.NextCursor;
            HasNextCursor = reader.HasNextCursor;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.EventsJson = EventsJson;
            writer.NextCursor = NextCursor;
            writer.HasNextCursor = HasNextCursor;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string EventsJson
        {
            get;
            set;
        }

        public string NextCursor
        {
            get;
            set;
        }

        public bool HasNextCursor
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string EventsJson => ctx.ReadText(0, null);
            public string NextCursor => ctx.ReadText(1, null);
            public bool HasNextCursor => ctx.ReadDataBool(0UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 2);
            }

            public string EventsJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string NextCursor
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public bool HasNextCursor
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8146d988aec5fe86UL)]
    public class AppendEventRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8146d988aec5fe86UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            EventType = reader.EventType;
            PayloadJson = reader.PayloadJson;
            Note = reader.Note;
            HasNote = reader.HasNote;
            MetadataJson = reader.MetadataJson;
            HasMetadata = reader.HasMetadata;
            PublishTargets = reader.PublishTargets?.ToReadOnlyList(_ => CapnpSerializable.Create<CapnpGen.PublishTarget>(_));
            HasPublishTargets = reader.HasPublishTargets;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.EventType = EventType;
            writer.PayloadJson = PayloadJson;
            writer.Note = Note;
            writer.HasNote = HasNote;
            writer.MetadataJson = MetadataJson;
            writer.HasMetadata = HasMetadata;
            writer.PublishTargets.Init(PublishTargets, (_s1, _v1) => _v1?.serialize(_s1));
            writer.HasPublishTargets = HasPublishTargets;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Token
        {
            get;
            set;
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public string EventType
        {
            get;
            set;
        }

        public string PayloadJson
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public bool HasNote
        {
            get;
            set;
        }

        public string MetadataJson
        {
            get;
            set;
        }

        public bool HasMetadata
        {
            get;
            set;
        }

        public IReadOnlyList<CapnpGen.PublishTarget> PublishTargets
        {
            get;
            set;
        }

        public bool HasPublishTargets
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Token => ctx.ReadText(0, null);
            public string AggregateType => ctx.ReadText(1, null);
            public string AggregateId => ctx.ReadText(2, null);
            public string EventType => ctx.ReadText(3, null);
            public string PayloadJson => ctx.ReadText(4, null);
            public string Note => ctx.ReadText(5, null);
            public bool HasNote => ctx.ReadDataBool(0UL, false);
            public string MetadataJson => ctx.ReadText(6, null);
            public bool HasMetadata => ctx.ReadDataBool(1UL, false);
            public IReadOnlyList<CapnpGen.PublishTarget.READER> PublishTargets => ctx.ReadList(7).Cast(CapnpGen.PublishTarget.READER.create);
            public bool HasPublishTargets => ctx.ReadDataBool(2UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 8);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateType
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public string EventType
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public string PayloadJson
            {
                get => this.ReadText(4, null);
                set => this.WriteText(4, value, null);
            }

            public string Note
            {
                get => this.ReadText(5, null);
                set => this.WriteText(5, value, null);
            }

            public bool HasNote
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string MetadataJson
            {
                get => this.ReadText(6, null);
                set => this.WriteText(6, value, null);
            }

            public bool HasMetadata
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public ListOfStructsSerializer<CapnpGen.PublishTarget.WRITER> PublishTargets
            {
                get => BuildPointer<ListOfStructsSerializer<CapnpGen.PublishTarget.WRITER>>(7);
                set => Link(7, value);
            }

            public bool HasPublishTargets
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd33d8cf951c96f5cUL)]
    public class AppendEventResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd33d8cf951c96f5cUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            EventJson = reader.EventJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.EventJson = EventJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string EventJson
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string EventJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public string EventJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf2ef076727f71b8bUL)]
    public class PatchEventRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xf2ef076727f71b8bUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            EventType = reader.EventType;
            PatchJson = reader.PatchJson;
            Note = reader.Note;
            HasNote = reader.HasNote;
            MetadataJson = reader.MetadataJson;
            HasMetadata = reader.HasMetadata;
            PublishTargets = reader.PublishTargets?.ToReadOnlyList(_ => CapnpSerializable.Create<CapnpGen.PublishTarget>(_));
            HasPublishTargets = reader.HasPublishTargets;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.EventType = EventType;
            writer.PatchJson = PatchJson;
            writer.Note = Note;
            writer.HasNote = HasNote;
            writer.MetadataJson = MetadataJson;
            writer.HasMetadata = HasMetadata;
            writer.PublishTargets.Init(PublishTargets, (_s1, _v1) => _v1?.serialize(_s1));
            writer.HasPublishTargets = HasPublishTargets;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Token
        {
            get;
            set;
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public string EventType
        {
            get;
            set;
        }

        public string PatchJson
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public bool HasNote
        {
            get;
            set;
        }

        public string MetadataJson
        {
            get;
            set;
        }

        public bool HasMetadata
        {
            get;
            set;
        }

        public IReadOnlyList<CapnpGen.PublishTarget> PublishTargets
        {
            get;
            set;
        }

        public bool HasPublishTargets
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Token => ctx.ReadText(0, null);
            public string AggregateType => ctx.ReadText(1, null);
            public string AggregateId => ctx.ReadText(2, null);
            public string EventType => ctx.ReadText(3, null);
            public string PatchJson => ctx.ReadText(4, null);
            public string Note => ctx.ReadText(5, null);
            public bool HasNote => ctx.ReadDataBool(0UL, false);
            public string MetadataJson => ctx.ReadText(6, null);
            public bool HasMetadata => ctx.ReadDataBool(1UL, false);
            public IReadOnlyList<CapnpGen.PublishTarget.READER> PublishTargets => ctx.ReadList(7).Cast(CapnpGen.PublishTarget.READER.create);
            public bool HasPublishTargets => ctx.ReadDataBool(2UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 8);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateType
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public string EventType
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public string PatchJson
            {
                get => this.ReadText(4, null);
                set => this.WriteText(4, value, null);
            }

            public string Note
            {
                get => this.ReadText(5, null);
                set => this.WriteText(5, value, null);
            }

            public bool HasNote
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string MetadataJson
            {
                get => this.ReadText(6, null);
                set => this.WriteText(6, value, null);
            }

            public bool HasMetadata
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public ListOfStructsSerializer<CapnpGen.PublishTarget.WRITER> PublishTargets
            {
                get => BuildPointer<ListOfStructsSerializer<CapnpGen.PublishTarget.WRITER>>(7);
                set => Link(7, value);
            }

            public bool HasPublishTargets
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbee2e069a128b66bUL)]
    public class VerifyAggregateRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xbee2e069a128b66bUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string AggregateType => ctx.ReadText(0, null);
            public string AggregateId => ctx.ReadText(1, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 2);
            }

            public string AggregateType
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa64d12d927785904UL)]
    public class VerifyAggregateResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa64d12d927785904UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            MerkleRoot = reader.MerkleRoot;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.MerkleRoot = MerkleRoot;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string MerkleRoot
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string MerkleRoot => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public string MerkleRoot
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9b63c43be10731dfUL)]
    public class SelectAggregateRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0x9b63c43be10731dfUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            Fields = reader.Fields;
            Token = reader.Token;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.Fields.Init(Fields);
            writer.Token = Token;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public IReadOnlyList<string> Fields
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string AggregateType => ctx.ReadText(0, null);
            public string AggregateId => ctx.ReadText(1, null);
            public IReadOnlyList<string> Fields => ctx.ReadList(2).CastText2();
            public string Token => ctx.ReadText(3, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 4);
            }

            public string AggregateType
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public ListOfTextSerializer Fields
            {
                get => BuildPointer<ListOfTextSerializer>(2);
                set => Link(2, value);
            }

            public string Token
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf79bbf1ce0695528UL)]
    public class SelectAggregateResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xf79bbf1ce0695528UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Found = reader.Found;
            SelectionJson = reader.SelectionJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Found = Found;
            writer.SelectionJson = SelectionJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Found
        {
            get;
            set;
        }

        public string SelectionJson
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public bool Found => ctx.ReadDataBool(0UL, false);
            public string SelectionJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public bool Found
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string SelectionJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbe6f8199b26b5662UL)]
    public class CreateAggregateRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xbe6f8199b26b5662UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            EventType = reader.EventType;
            PayloadJson = reader.PayloadJson;
            Note = reader.Note;
            HasNote = reader.HasNote;
            MetadataJson = reader.MetadataJson;
            HasMetadata = reader.HasMetadata;
            PublishTargets = reader.PublishTargets?.ToReadOnlyList(_ => CapnpSerializable.Create<CapnpGen.PublishTarget>(_));
            HasPublishTargets = reader.HasPublishTargets;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.EventType = EventType;
            writer.PayloadJson = PayloadJson;
            writer.Note = Note;
            writer.HasNote = HasNote;
            writer.MetadataJson = MetadataJson;
            writer.HasMetadata = HasMetadata;
            writer.PublishTargets.Init(PublishTargets, (_s1, _v1) => _v1?.serialize(_s1));
            writer.HasPublishTargets = HasPublishTargets;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Token
        {
            get;
            set;
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public string EventType
        {
            get;
            set;
        }

        public string PayloadJson
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public bool HasNote
        {
            get;
            set;
        }

        public string MetadataJson
        {
            get;
            set;
        }

        public bool HasMetadata
        {
            get;
            set;
        }

        public IReadOnlyList<CapnpGen.PublishTarget> PublishTargets
        {
            get;
            set;
        }

        public bool HasPublishTargets
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Token => ctx.ReadText(0, null);
            public string AggregateType => ctx.ReadText(1, null);
            public string AggregateId => ctx.ReadText(2, null);
            public string EventType => ctx.ReadText(3, null);
            public string PayloadJson => ctx.ReadText(4, null);
            public string Note => ctx.ReadText(5, null);
            public bool HasNote => ctx.ReadDataBool(0UL, false);
            public string MetadataJson => ctx.ReadText(6, null);
            public bool HasMetadata => ctx.ReadDataBool(1UL, false);
            public IReadOnlyList<CapnpGen.PublishTarget.READER> PublishTargets => ctx.ReadList(7).Cast(CapnpGen.PublishTarget.READER.create);
            public bool HasPublishTargets => ctx.ReadDataBool(2UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 8);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateType
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public string EventType
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public string PayloadJson
            {
                get => this.ReadText(4, null);
                set => this.WriteText(4, value, null);
            }

            public string Note
            {
                get => this.ReadText(5, null);
                set => this.WriteText(5, value, null);
            }

            public bool HasNote
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string MetadataJson
            {
                get => this.ReadText(6, null);
                set => this.WriteText(6, value, null);
            }

            public bool HasMetadata
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public ListOfStructsSerializer<CapnpGen.PublishTarget.WRITER> PublishTargets
            {
                get => BuildPointer<ListOfStructsSerializer<CapnpGen.PublishTarget.WRITER>>(7);
                set => Link(7, value);
            }

            public bool HasPublishTargets
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf5773d8bcb25a676UL)]
    public class CreateAggregateResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xf5773d8bcb25a676UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            AggregateJson = reader.AggregateJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.AggregateJson = AggregateJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string AggregateJson
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string AggregateJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public string AggregateJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9a0614143a5298b6UL)]
    public class SetAggregateArchiveRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0x9a0614143a5298b6UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            Archived = reader.Archived;
            Note = reader.Note;
            HasNote = reader.HasNote;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.Archived = Archived;
            writer.Note = Note;
            writer.HasNote = HasNote;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Token
        {
            get;
            set;
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public bool Archived
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public bool HasNote
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Token => ctx.ReadText(0, null);
            public string AggregateType => ctx.ReadText(1, null);
            public string AggregateId => ctx.ReadText(2, null);
            public bool Archived => ctx.ReadDataBool(0UL, false);
            public string Note => ctx.ReadText(3, null);
            public bool HasNote => ctx.ReadDataBool(1UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 4);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateType
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public bool Archived
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string Note
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public bool HasNote
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe118c70152f46295UL)]
    public class SetAggregateArchiveResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe118c70152f46295UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            AggregateJson = reader.AggregateJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.AggregateJson = AggregateJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string AggregateJson
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string AggregateJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public string AggregateJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xaa1e4bcfa27cda1aUL)]
    public class CreateSnapshotRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xaa1e4bcfa27cda1aUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            Comment = reader.Comment;
            HasComment = reader.HasComment;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.Comment = Comment;
            writer.HasComment = HasComment;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Token
        {
            get;
            set;
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }

        public bool HasComment
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Token => ctx.ReadText(0, null);
            public string AggregateType => ctx.ReadText(1, null);
            public string AggregateId => ctx.ReadText(2, null);
            public string Comment => ctx.ReadText(3, null);
            public bool HasComment => ctx.ReadDataBool(0UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 4);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateType
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public string Comment
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public bool HasComment
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfaa038aa19d14ab1UL)]
    public class CreateSnapshotResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xfaa038aa19d14ab1UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            SnapshotJson = reader.SnapshotJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.SnapshotJson = SnapshotJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string SnapshotJson
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string SnapshotJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public string SnapshotJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd2c07d9608094b97UL)]
    public class PublishTarget : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd2c07d9608094b97UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Plugin = reader.Plugin;
            Mode = reader.Mode;
            HasMode = reader.HasMode;
            Priority = reader.Priority;
            HasPriority = reader.HasPriority;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Plugin = Plugin;
            writer.Mode = Mode;
            writer.HasMode = HasMode;
            writer.Priority = Priority;
            writer.HasPriority = HasPriority;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Plugin
        {
            get;
            set;
        }

        public string Mode
        {
            get;
            set;
        }

        public bool HasMode
        {
            get;
            set;
        }

        public string Priority
        {
            get;
            set;
        }

        public bool HasPriority
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Plugin => ctx.ReadText(0, null);
            public string Mode => ctx.ReadText(1, null);
            public bool HasMode => ctx.ReadDataBool(0UL, false);
            public string Priority => ctx.ReadText(2, null);
            public bool HasPriority => ctx.ReadDataBool(1UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 3);
            }

            public string Plugin
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string Mode
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public bool HasMode
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string Priority
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public bool HasPriority
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf36702ef317a3203UL)]
    public class ListSnapshotsRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xf36702ef317a3203UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            AggregateType = reader.AggregateType;
            AggregateId = reader.AggregateId;
            HasAggregateType = reader.HasAggregateType;
            HasAggregateId = reader.HasAggregateId;
            Version = reader.Version;
            HasVersion = reader.HasVersion;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.AggregateType = AggregateType;
            writer.AggregateId = AggregateId;
            writer.HasAggregateType = HasAggregateType;
            writer.HasAggregateId = HasAggregateId;
            writer.Version = Version;
            writer.HasVersion = HasVersion;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Token
        {
            get;
            set;
        }

        public string AggregateType
        {
            get;
            set;
        }

        public string AggregateId
        {
            get;
            set;
        }

        public bool HasAggregateType
        {
            get;
            set;
        }

        public bool HasAggregateId
        {
            get;
            set;
        }

        public ulong Version
        {
            get;
            set;
        }

        public bool HasVersion
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Token => ctx.ReadText(0, null);
            public string AggregateType => ctx.ReadText(1, null);
            public string AggregateId => ctx.ReadText(2, null);
            public bool HasAggregateType => ctx.ReadDataBool(0UL, false);
            public bool HasAggregateId => ctx.ReadDataBool(1UL, false);
            public ulong Version => ctx.ReadDataULong(64UL, 0UL);
            public bool HasVersion => ctx.ReadDataBool(2UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 3);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AggregateType
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string AggregateId
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public bool HasAggregateType
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public bool HasAggregateId
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public ulong Version
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public bool HasVersion
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x98fb1aea27e65a80UL)]
    public class ListSnapshotsResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0x98fb1aea27e65a80UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            SnapshotsJson = reader.SnapshotsJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.SnapshotsJson = SnapshotsJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string SnapshotsJson
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string SnapshotsJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public string SnapshotsJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb194ac43ee46d2feUL)]
    public class GetSnapshotRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xb194ac43ee46d2feUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            SnapshotId = reader.SnapshotId;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.SnapshotId = SnapshotId;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Token
        {
            get;
            set;
        }

        public ulong SnapshotId
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Token => ctx.ReadText(0, null);
            public ulong SnapshotId => ctx.ReadDataULong(0UL, 0UL);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public ulong SnapshotId
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xcd81436bed1e7e9aUL)]
    public class GetSnapshotResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xcd81436bed1e7e9aUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Found = reader.Found;
            SnapshotJson = reader.SnapshotJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Found = Found;
            writer.SnapshotJson = SnapshotJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Found
        {
            get;
            set;
        }

        public string SnapshotJson
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public bool Found => ctx.ReadDataBool(0UL, false);
            public string SnapshotJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public bool Found
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string SnapshotJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe8509915756b10e1UL)]
    public class ControlError : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe8509915756b10e1UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Code = reader.Code;
            Message = reader.Message;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Code = Code;
            writer.Message = Message;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Code
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string Code => ctx.ReadText(0, null);
            public string Message => ctx.ReadText(1, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 2);
            }

            public string Code
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string Message
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }
        }
    }
}