using Capnp;
using Capnp.Rpc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CapnpGen
{
    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd079d5b344674355UL)]
    public class ListSchemasRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd079d5b344674355UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
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
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe5defb7b73059430UL)]
    public class ListSchemasResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe5defb7b73059430UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            SchemasJson = reader.SchemasJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.SchemasJson = SchemasJson;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string SchemasJson
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
            public string SchemasJson => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public string SchemasJson
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa175171dd5e804e2UL)]
    public class ReplaceSchemasRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa175171dd5e804e2UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            SchemasJson = reader.SchemasJson;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.SchemasJson = SchemasJson;
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

        public string SchemasJson
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
            public string SchemasJson => ctx.ReadText(1, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 2);
            }

            public string Token
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string SchemasJson
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd939aef8a6a81647UL)]
    public class ReplaceSchemasResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd939aef8a6a81647UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Replaced = reader.Replaced;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Replaced = Replaced;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public uint Replaced
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
            public uint Replaced => ctx.ReadDataUInt(0UL, 0U);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public uint Replaced
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa513f071dd65d5f2UL)]
    public class TenantAssignRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa513f071dd65d5f2UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            TenantId = reader.TenantId;
            ShardId = reader.ShardId;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.TenantId = TenantId;
            writer.ShardId = ShardId;
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

        public string TenantId
        {
            get;
            set;
        }

        public string ShardId
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
            public string TenantId => ctx.ReadText(1, null);
            public string ShardId => ctx.ReadText(2, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 3);
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

            public string ShardId
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd6dc3540587e7024UL)]
    public class TenantAssignResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd6dc3540587e7024UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Changed = reader.Changed;
            ShardId = reader.ShardId;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Changed = Changed;
            writer.ShardId = ShardId;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Changed
        {
            get;
            set;
        }

        public string ShardId
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
            public bool Changed => ctx.ReadDataBool(0UL, false);
            public string ShardId => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public bool Changed
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string ShardId
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa69a5b6c85d883b1UL)]
    public class TenantUnassignRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa69a5b6c85d883b1UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            TenantId = reader.TenantId;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.TenantId = TenantId;
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

        public string TenantId
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
            public string TenantId => ctx.ReadText(1, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 2);
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
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa39efe48b2cf1900UL)]
    public class TenantUnassignResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa39efe48b2cf1900UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Changed = reader.Changed;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Changed = Changed;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Changed
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
            public bool Changed => ctx.ReadDataBool(0UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public bool Changed
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa1c40ed035717bb8UL)]
    public class TenantQuotaSetRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa1c40ed035717bb8UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            TenantId = reader.TenantId;
            MaxStorageMb = reader.MaxStorageMb;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.TenantId = TenantId;
            writer.MaxStorageMb = MaxStorageMb;
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

        public string TenantId
        {
            get;
            set;
        }

        public ulong MaxStorageMb
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
            public string TenantId => ctx.ReadText(1, null);
            public ulong MaxStorageMb => ctx.ReadDataULong(0UL, 0UL);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 2);
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

            public ulong MaxStorageMb
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x898b9f3ca77e6fecUL)]
    public class TenantQuotaSetResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0x898b9f3ca77e6fecUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Changed = reader.Changed;
            QuotaMb = reader.QuotaMb;
            HasQuota = reader.HasQuota;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Changed = Changed;
            writer.QuotaMb = QuotaMb;
            writer.HasQuota = HasQuota;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Changed
        {
            get;
            set;
        }

        public ulong QuotaMb
        {
            get;
            set;
        }

        public bool HasQuota
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
            public bool Changed => ctx.ReadDataBool(0UL, false);
            public ulong QuotaMb => ctx.ReadDataULong(64UL, 0UL);
            public bool HasQuota => ctx.ReadDataBool(1UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 0);
            }

            public bool Changed
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public ulong QuotaMb
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public bool HasQuota
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa5231ddd185cd50cUL)]
    public class TenantQuotaClearRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa5231ddd185cd50cUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            TenantId = reader.TenantId;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.TenantId = TenantId;
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

        public string TenantId
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
            public string TenantId => ctx.ReadText(1, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 2);
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
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa630c83367353a33UL)]
    public class TenantQuotaClearResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa630c83367353a33UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Changed = reader.Changed;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Changed = Changed;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Changed
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
            public bool Changed => ctx.ReadDataBool(0UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public bool Changed
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xcdcc09b4ae6040fbUL)]
    public class TenantQuotaRecalcRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xcdcc09b4ae6040fbUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            TenantId = reader.TenantId;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.TenantId = TenantId;
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

        public string TenantId
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
            public string TenantId => ctx.ReadText(1, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 2);
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
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe2f61310a3bffd69UL)]
    public class TenantQuotaRecalcResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe2f61310a3bffd69UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            StorageBytes = reader.StorageBytes;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.StorageBytes = StorageBytes;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong StorageBytes
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
            public ulong StorageBytes => ctx.ReadDataULong(0UL, 0UL);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public ulong StorageBytes
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc5420845a89a47b8UL)]
    public class TenantReloadRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc5420845a89a47b8UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            TenantId = reader.TenantId;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.TenantId = TenantId;
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

        public string TenantId
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
            public string TenantId => ctx.ReadText(1, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 2);
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
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xaccf8712e71bf2d4UL)]
    public class TenantReloadResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xaccf8712e71bf2d4UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Reloaded = reader.Reloaded;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Reloaded = Reloaded;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Reloaded
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
            public bool Reloaded => ctx.ReadDataBool(0UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public bool Reloaded
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x80f699241ca9c2a7UL)]
    public class TenantSchemaPublishRequest : ICapnpSerializable
    {
        public const UInt64 typeId = 0x80f699241ca9c2a7UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Token = reader.Token;
            TenantId = reader.TenantId;
            Reason = reader.Reason;
            HasReason = reader.HasReason;
            Actor = reader.Actor;
            HasActor = reader.HasActor;
            Labels = reader.Labels;
            Activate = reader.Activate;
            Force = reader.Force;
            Reload = reader.Reload;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Token = Token;
            writer.TenantId = TenantId;
            writer.Reason = Reason;
            writer.HasReason = HasReason;
            writer.Actor = Actor;
            writer.HasActor = HasActor;
            writer.Labels.Init(Labels);
            writer.Activate = Activate;
            writer.Force = Force;
            writer.Reload = Reload;
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

        public string TenantId
        {
            get;
            set;
        }

        public string Reason
        {
            get;
            set;
        }

        public bool HasReason
        {
            get;
            set;
        }

        public string Actor
        {
            get;
            set;
        }

        public bool HasActor
        {
            get;
            set;
        }

        public IReadOnlyList<string> Labels
        {
            get;
            set;
        }

        public bool Activate
        {
            get;
            set;
        }

        public bool Force
        {
            get;
            set;
        }

        public bool Reload
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
            public string TenantId => ctx.ReadText(1, null);
            public string Reason => ctx.ReadText(2, null);
            public bool HasReason => ctx.ReadDataBool(0UL, false);
            public string Actor => ctx.ReadText(3, null);
            public bool HasActor => ctx.ReadDataBool(1UL, false);
            public IReadOnlyList<string> Labels => ctx.ReadList(4).CastText2();
            public bool Activate => ctx.ReadDataBool(2UL, false);
            public bool Force => ctx.ReadDataBool(3UL, false);
            public bool Reload => ctx.ReadDataBool(4UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 5);
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

            public string Reason
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public bool HasReason
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string Actor
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public bool HasActor
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public ListOfTextSerializer Labels
            {
                get => BuildPointer<ListOfTextSerializer>(4);
                set => Link(4, value);
            }

            public bool Activate
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }

            public bool Force
            {
                get => this.ReadDataBool(3UL, false);
                set => this.WriteData(3UL, value, false);
            }

            public bool Reload
            {
                get => this.ReadDataBool(4UL, false);
                set => this.WriteData(4UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd7ba55d072ea0526UL)]
    public class TenantSchemaPublishResponse : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd7ba55d072ea0526UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            VersionId = reader.VersionId;
            Activated = reader.Activated;
            Skipped = reader.Skipped;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.VersionId = VersionId;
            writer.Activated = Activated;
            writer.Skipped = Skipped;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string VersionId
        {
            get;
            set;
        }

        public bool Activated
        {
            get;
            set;
        }

        public bool Skipped
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
            public string VersionId => ctx.ReadText(0, null);
            public bool Activated => ctx.ReadDataBool(0UL, false);
            public bool Skipped => ctx.ReadDataBool(1UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public string VersionId
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public bool Activated
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public bool Skipped
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }
        }
    }
}