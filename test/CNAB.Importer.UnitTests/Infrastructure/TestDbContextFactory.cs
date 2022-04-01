using CNAB.Importer.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace CNAB.Importer.UnitTests.Infrastructure;

public class TestDbContextFactory : IDbContextFactory<ImporterContext>
{
    private readonly DbContextOptions<ImporterContext> _options;

    public TestDbContextFactory()
    {
        _options = new DbContextOptionsBuilder<ImporterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
    }

    public ImporterContext CreateDbContext()
    {
        return new ImporterContext(_options);
    }
}