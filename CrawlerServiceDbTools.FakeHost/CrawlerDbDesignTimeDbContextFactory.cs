using CrawlerServiceDbPart.Db;
using CrawlerServiceDbTools.DbMigration;
using Microsoft.EntityFrameworkCore;
using SystemTools.DatabaseToolsShared;

namespace CrawlerServiceDbTools.FakeHost;

//ეს კლასი საჭიროა იმისათვის, რომ შესაძლებელი გახდეს მიგრაციასთან მუშაობა.
//ანუ დეველოპერ ბაზის წაშლა და ახლიდან დაგენერირება, ან მიგრაციაში ცვლილებების გაკეთება
// ReSharper disable once UnusedType.Global
public sealed class CrawlerDbDesignTimeDbContextFactory : SqlServerDesignTimeDbContextFactory<CrawlerDbContext>
{
    //DataProvider მოდის FakeHost პროექტის appsettings.json ფაილიდან,
    //ხოლო ConnectionString, როგორც დაცული ინფორმაცია, FakeHost-ის User Secrets-იდან (UserSecretsId წერია csproj-ში).
    //კონსტრუქტორი აუცილებლად უპარამეტრო უნდა იყოს, რადგან dotnet ef ამ კლასს თვითონ ქმნის რეფლექსიით
    // ReSharper disable once ConvertToPrimaryConstructor
    public CrawlerDbDesignTimeDbContextFactory() : base(AssemblyReference.Assembly.GetName().Name!, "ConnectionString",
        true)
    {
    }

    protected override CrawlerDbContext CreateDbContext(DbContextOptions<CrawlerDbContext> options)
    {
        // ReSharper disable once DisposableConstructor
        return new CrawlerDbContext(options);
    }
}
