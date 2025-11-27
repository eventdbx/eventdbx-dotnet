using System.Buffers.Binary;
using Capnp;

namespace EventDbx;

internal static class CapnpCodec
{
    public static byte[] Serialize<TWriter>(ICapnpSerializable message)
        where TWriter : SerializerState, new()
    {
        var builder = MessageBuilder.Create();
        var writer = builder.BuildRoot<TWriter>();
        message.Serialize(writer);
        return Serialize(builder.Frame);
    }

    public static WireFrame DeserializeFrame(ReadOnlySpan<byte> data)
    {
        var (frame, consumed) = ParseFrame(data);
        if (consumed != data.Length)
        {
            throw new InvalidOperationException("Unexpected trailing bytes after Cap'n Proto frame");
        }
        return frame;
    }

    public static (WireFrame Frame, int Consumed) ParseFrame(ReadOnlySpan<byte> data)
    {
        if (data.Length < 8)
        {
            throw new InvalidOperationException("Cap'n Proto frame header is incomplete");
        }

        var segmentCount = (int)BinaryPrimitives.ReadUInt32LittleEndian(data) + 1;
        if (segmentCount <= 0)
        {
            throw new InvalidOperationException("Cap'n Proto frame has no segments");
        }

        var firstLength = (int)BinaryPrimitives.ReadUInt32LittleEndian(data.Slice(4));
        var lengths = new int[segmentCount];
        lengths[0] = firstLength;

        var headerEntries = segmentCount + 1;
        if ((headerEntries & 1) != 0)
        {
            headerEntries++;
        }
        var headerBytes = headerEntries * sizeof(uint);
        if (data.Length < headerBytes)
        {
            throw new InvalidOperationException("Cap'n Proto frame header is truncated");
        }

        var offset = 8;
        for (var i = 1; i < segmentCount; i++)
        {
            lengths[i] = (int)BinaryPrimitives.ReadUInt32LittleEndian(data.Slice(offset));
            offset += 4;
        }

        offset = headerBytes;
        var segments = new List<Memory<ulong>>(segmentCount);
        for (var i = 0; i < segmentCount; i++)
        {
            var words = lengths[i];
            var bytes = checked(words * sizeof(ulong));
            if (offset + bytes > data.Length)
            {
                throw new InvalidOperationException("Cap'n Proto frame segment is truncated");
            }

            var segmentWords = new ulong[words];
            var span = data.Slice(offset, bytes);
            for (var w = 0; w < words; w++)
            {
                segmentWords[w] = BinaryPrimitives.ReadUInt64LittleEndian(span.Slice(w * 8));
            }

            segments.Add(segmentWords);
            offset += bytes;
        }

        return (new WireFrame(segments), offset);
    }

    public static async Task<WireFrame> ReadFrameFromStreamAsync(Stream stream, CancellationToken cancellationToken)
    {
        var header = new byte[8];
        await ReadExactAsync(stream, header, cancellationToken).ConfigureAwait(false);

        var segmentCount = (int)BinaryPrimitives.ReadUInt32LittleEndian(header) + 1;
        var lengths = new int[segmentCount];
        lengths[0] = (int)BinaryPrimitives.ReadUInt32LittleEndian(header.AsSpan(4));

        var headerEntries = segmentCount + 1;
        if ((headerEntries & 1) != 0)
        {
            headerEntries++;
        }

        var remainingHeaderBytes = (headerEntries - 2) * sizeof(uint);
        if (remainingHeaderBytes > 0)
        {
            var buffer = new byte[remainingHeaderBytes];
            await ReadExactAsync(stream, buffer, cancellationToken).ConfigureAwait(false);
            var offset = 0;
            for (var i = 1; i < segmentCount; i++)
            {
                lengths[i] = (int)BinaryPrimitives.ReadUInt32LittleEndian(buffer.AsSpan(offset));
                offset += 4;
            }
        }

        var segments = new List<Memory<ulong>>(segmentCount);
        for (var i = 0; i < segmentCount; i++)
        {
            var words = lengths[i];
            var bytes = checked(words * sizeof(ulong));
            var buffer = new byte[bytes];
            if (bytes > 0)
            {
                await ReadExactAsync(stream, buffer, cancellationToken).ConfigureAwait(false);
            }

            var segmentWords = new ulong[words];
            if (words > 0)
            {
                Buffer.BlockCopy(buffer, 0, segmentWords, 0, bytes);
            }
            segments.Add(segmentWords);
        }

        return new WireFrame(segments);
    }

    public static byte[] Serialize(WireFrame frame)
    {
        var segments = frame.Segments;
        var segmentCount = segments.Count;
        if (segmentCount == 0)
        {
            return Array.Empty<byte>();
        }

        var lengths = new int[segmentCount];
        var payloadBytes = 0;
        for (var i = 0; i < segmentCount; i++)
        {
            lengths[i] = segments[i].Length;
            payloadBytes += lengths[i] * sizeof(ulong);
        }

        var headerEntries = segmentCount + 1;
        if ((headerEntries & 1) != 0)
        {
            headerEntries++;
        }
        var headerBytes = headerEntries * sizeof(uint);

        var buffer = new byte[headerBytes + payloadBytes];
        BinaryPrimitives.WriteUInt32LittleEndian(buffer, (uint)(segmentCount - 1));
        BinaryPrimitives.WriteUInt32LittleEndian(buffer.AsSpan(4), (uint)lengths[0]);
        for (var i = 1; i < segmentCount; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(buffer.AsSpan((i + 1) * 4), (uint)lengths[i]);
        }

        var offset = headerBytes;
        for (var i = 0; i < segmentCount; i++)
        {
            var segment = segments[i].Span;
            var bytes = lengths[i] * sizeof(ulong);
            var dest = buffer.AsSpan(offset, bytes);
            for (var w = 0; w < lengths[i]; w++)
            {
                BinaryPrimitives.WriteUInt64LittleEndian(dest.Slice(w * 8), segment[w]);
            }
            offset += bytes;
        }

        return buffer;
    }

    private static async Task ReadExactAsync(Stream stream, byte[] buffer, CancellationToken cancellationToken)
    {
        var remaining = buffer.Length;
        var offset = 0;
        while (remaining > 0)
        {
            var read = await stream.ReadAsync(buffer.AsMemory(offset, remaining), cancellationToken).ConfigureAwait(false);
            if (read == 0)
            {
                throw new IOException("Stream closed while reading Cap'n Proto frame");
            }
            offset += read;
            remaining -= read;
        }
    }
}
