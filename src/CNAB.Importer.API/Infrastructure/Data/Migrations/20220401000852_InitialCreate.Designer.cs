﻿// <auto-generated />
using System;
using CNAB.Importer.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CNAB.Importer.API.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ImporterContext))]
    [Migration("20220401000852_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CNAB.Importer.API.Infrastructure.Data.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Hour")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("varchar(19)");

                    b.Property<string>("StoreOwnerName")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("Date")
                        .IsUnique();

                    b.HasIndex("StoreName")
                        .IsUnique();

                    b.HasIndex("StoreOwnerName")
                        .IsUnique();

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CNAB.Importer.API.Infrastructure.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}