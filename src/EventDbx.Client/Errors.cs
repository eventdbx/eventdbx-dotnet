using System.IO;

namespace EventDbx;

public class EventDbxException : Exception
{
    public EventDbxException(string message)
        : base(message)
    {
    }

    public EventDbxException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

public sealed class EventDbxApiException : EventDbxException
{
    public EventDbxApiException(string code, string message)
        : base(message)
    {
        Code = code;
    }

    public string Code { get; }
}

public sealed class EventDbxHandshakeException : EventDbxException
{
    public EventDbxHandshakeException(string message)
        : base(message)
    {
    }
}

public sealed class EventDbxConnectionException : EventDbxException
{
    public EventDbxConnectionException(string message, Exception? inner = null)
        : base(message, inner ?? new IOException(message))
    {
    }
}
