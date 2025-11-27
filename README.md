# EventDBX .NET Client

Preview C#/.NET SDK for the EventDBX control plane. The client mirrors the Rust/Python implementations: it speaks the Cap'n Proto TCP protocol, performs the Noise NNpsk0 handshake by default, and exposes helpers for aggregates, events, snapshots, schemas, and tenant admin.

## Building

A local SDK is already bootstrapped under `.dotnet/` in this repo. Use it directly or rely on a system `dotnet` install:

```bash
# using the bundled SDK
DOTNET_ROOT=$(pwd)/.dotnet PATH="$DOTNET_ROOT:$PATH" dotnet build
```

Cap'n Proto types are generated into `src/EventDbx.Client/Generated/proto/` via `capnpc-csharp`. Regenerate after schema changes with:

```bash
DOTNET_ROOT=$(pwd)/.dotnet PATH="$DOTNET_ROOT:$PATH" \
  PATH="$(pwd)/.dotnet-tools:$PATH" \
  capnp compile -ocsharp:src/EventDbx.Client/Generated -Iproto proto/control.capnp proto/schema.capnp
```

## Packaging (NuGet)

Pack the client from the repo root (adjust `PackageVersion` as needed):

```bash
DOTNET_ROOT=$(pwd)/.dotnet PATH="$DOTNET_ROOT:$PATH" \
  dotnet pack src/EventDbx.Client/EventDbx.Client.csproj \
  -c Release /p:PackageVersion=0.1.0-preview1
```

Packages land in `artifacts/nuget/` alongside symbols and include this README as the NuGet readme.

## CI/CD

- CI: runs on PRs and pushes to `main` (`.github/workflows/ci.yml`) and executes restore, build, and tests in `Release`.
- Release: runs on tags matching `v*` or manual dispatch with a `version` input (`.github/workflows/release.yml`). It builds/tests, packs with `/p:PackageVersion=<tag>`, uploads artifacts, pushes to NuGet.org, and creates a GitHub release with attached packages.
- Version bump: manual workflow to create the next semver tag and trigger the release flow (`.github/workflows/version-bump.yml`). Inputs: `release_type` = patch/minor/major.
- Secrets: add `NUGET_API_KEY` (Publish API key from nuget.org) in repo settings. The workflow skips publish if it is absent.

## Usage

```csharp
using EventDbx;

var client = await EventDbxClient.ConnectAsync(new EventDbxClientOptions
{
    Host = "127.0.0.1",
    Port = 6363,
    Token = "control-token",
    TenantId = "tenant-123",
});

// append an event
await client.AppendEventAsync(new AppendEventParams
{
    AggregateType = "orders",
    AggregateId = "ord_1",
    EventType = "created",
    Payload = new { total = 42.15 },
});

// list aggregates
var aggregates = await client.ListAggregatesAsync(new ListAggregatesOptions
{
    Take = 50,
    SortText = "created_at:desc",
});

// fetch events
var eventsPage = await client.ListEventsAsync("orders", "ord_1");

await client.DisposeAsync();
```

The client can disable Noise by setting `UseNoise = false` in `EventDbxClientOptions` (useful only for plaintext test sockets).

## Notes

- Generated code currently emits nullable warnings; they are cosmetic and stem from the Cap'n Proto generator.
- Frames are limited to 16 MiB to align with the other SDKs.
