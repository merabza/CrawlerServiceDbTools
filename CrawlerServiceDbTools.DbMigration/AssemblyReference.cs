using System.Reflection;

namespace CrawlerServiceDbTools.DbMigration;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
