namespace EventDbx.Client.Tests;

internal sealed record TestEndpoint(string Host, int Port, string Token, string TenantId)
{
    public static TestEndpoint? TryLoad(out string? reason)
    {
        string? host = Environment.GetEnvironmentVariable("EVENTDBX_HOST");
        string? token = Environment.GetEnvironmentVariable("EVENTDBX_TOKEN");
        string? tenant = Environment.GetEnvironmentVariable("EVENTDBX_TENANT");
        string? portRaw = Environment.GetEnvironmentVariable("EVENTDBX_PORT");

        if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(token))
        {
            reason = "Set EVENTDBX_HOST and EVENTDBX_TOKEN to run integration tests.";
            return null;
        }

        int port = 6363;
        if (!string.IsNullOrWhiteSpace(portRaw) && int.TryParse(portRaw, out var parsed))
        {
            port = parsed;
        }

        tenant ??= "default";
        reason = null;
        return new TestEndpoint(host, port, token, tenant);
    }
}
