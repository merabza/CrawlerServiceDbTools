# CrawlerServiceDbTools

Database tooling solution for [CrawlerService](https://github.com/merabza/CrawlerService). It owns the EF Core migrations assembly and the design-time host used to (re)create and migrate the CrawlerService database via SupportTools or `dotnet ef`.

## Projects

| Project | Purpose |
|---|---|
| `CrawlerServiceDbTools.DbMigration` | EF Core migrations assembly for `CrawlerDbContext` |
| `CrawlerServiceDbTools.FakeHost` | Design-time host for `dotnet ef` only; not deployed |

## Repository layout — sibling repos are required

The solution references sibling clones by relative path (`../CrawlerService/...`, `../SystemTools/...`):

```
CrawlerServiceDbTools\           (container folder)
├── CrawlerService\              (github.com/merabza/CrawlerService — CrawlerDbModels, CrawlerDbPersistence)
├── SystemTools\                 (github.com/merabza/SystemTools)
└── CrawlerServiceDbTools\       (this repo, CrawlerServiceDbTools.slnx lives here)
```

## Usage

Requirements: .NET 10 SDK, `dotnet-ef` tool, SQL Server.

The connection string comes from the FakeHost user secrets (key `ConnectionString`):

```
dotnet user-secrets set ConnectionString "<connection string>" --project CrawlerServiceDbTools.FakeHost
```

Apply migrations / update the database:

```
dotnet ef database update --project CrawlerServiceDbTools.DbMigration --startup-project CrawlerServiceDbTools.FakeHost
```

Add a migration:

```
dotnet ef migrations add <Name> --project CrawlerServiceDbTools.DbMigration --startup-project CrawlerServiceDbTools.FakeHost
```

## License

MIT
