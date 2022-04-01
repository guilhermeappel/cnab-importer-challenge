using CNAB.Importer.API.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNAB.Importer.API.Infrastructure.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder
            .HasKey(b => b.Id);

        builder
            .HasIndex(b => b.Date)
            .IsUnique();

        builder
            .HasIndex(b => b.StoreName)
            .IsUnique();

        builder
            .HasIndex(b => b.StoreOwnerName)
            .IsUnique();

        builder
            .Property(b => b.Type)
            .HasColumnType("smallint");

        builder
            .Property(b => b.Date)
            .HasColumnType("date");

        builder
            .Property(b => b.Value)
            .HasColumnType("decimal");

        builder
            .Property(b => b.Document)
            .HasColumnType("varchar(11)");

        builder
            .Property(b => b.Card)
            .HasColumnType("varchar(12)");

        builder
            .Property(b => b.Hour)
            .HasColumnType("varchar(6)");

        builder
            .Property(b => b.StoreOwnerName)
            .HasColumnType("varchar(14)");

        builder
            .Property(b => b.StoreName)
            .HasColumnType("varchar(19)");
    }
}