using CNAB.Importer.API.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CNAB.Importer.API.Infrastructure.Data;

public class ImporterContext : DbContext
{
    public ImporterContext(DbContextOptions<ImporterContext> options) : base(options) { }

    public DbSet<User> Users { get; private set; }
    public DbSet<Transaction> Transactions { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImporterContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}