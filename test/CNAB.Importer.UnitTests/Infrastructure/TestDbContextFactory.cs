using CNAB.Importer.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CNAB.Importer.UnitTests.Infrastructure;

public class TestDbContextFactory : IDbContextFactory<ImporterContext>
{
    private readonly DbContextOptions<ImporterContext> _options;

    public TestDbContextFactory(string databaseName = "test-db")
    {
        _options = new DbContextOptionsBuilder<ImporterContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;
    }

    public ImporterContext CreateDbContext()
    {
        return new ImporterContext(_options);
    }
}