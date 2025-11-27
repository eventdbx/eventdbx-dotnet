using System.Threading.Tasks;
using Xunit;

namespace EventDbx.Client.Tests;

public class IntegrationTests
{
    [Fact]
    public async Task ConnectAndListAggregates()
    {
        var endpoint = TestEndpoint.TryLoad(out var reason);
        if (endpoint is null)
        {
            // Integration endpoint not configured; treat as skipped.
            return;
        }

        await using var client = await EventDbxClient.ConnectAsync(new EventDbxClientOptions
        {
            Host = endpoint!.Host,
            Port = endpoint.Port,
            Token = endpoint.Token,
            TenantId = endpoint.TenantId,
            UseNoise = true,
            RequestTimeout = System.TimeSpan.FromSeconds(10),
        });

        var page = await client.ListAggregatesAsync(new ListAggregatesOptions
        {
            Take = 1,
            SortText = "created_at:desc",
        });

        Assert.NotNull(page);
        Assert.False(string.IsNullOrWhiteSpace(page.AggregatesJson));
    }

    [Fact]
    public async Task ListSchemas()
    {
        var endpoint = TestEndpoint.TryLoad(out var reason);
        if (endpoint is null)
        {
            return;
        }

        await using var client = await EventDbxClient.ConnectAsync(new EventDbxClientOptions
        {
            Host = endpoint!.Host,
            Port = endpoint.Port,
            Token = endpoint.Token,
            TenantId = endpoint.TenantId,
            UseNoise = true,
            RequestTimeout = System.TimeSpan.FromSeconds(10),
        });

        var schemas = await client.ListSchemasAsync();
        Assert.False(string.IsNullOrWhiteSpace(schemas));
    }
}
