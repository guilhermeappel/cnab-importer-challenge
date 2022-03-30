using CNAB.Importer.API.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNAB.Importer.API.Infrastructure.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(b => b.Id);

        builder
            .HasIndex(b => b.Email)
            .IsUnique();

        builder
            .Property(b => b.Email)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(b => b.Password)
            .IsRequired()
            .HasColumnType("varchar(20)");
    }
}