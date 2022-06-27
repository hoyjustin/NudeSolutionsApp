﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NudeApp.Data;

namespace NudeApp.Migrations
{
    [DbContext(typeof(NudeAppContext))]
    partial class NudeAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NudeApp.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("1ab2eb38-22b0-4643-9730-402b6e68c2e9"),
                            Name = "None"
                        },
                        new
                        {
                            CategoryId = new Guid("bdf8686d-0fac-466e-9ac8-9bb73dc9db60"),
                            Name = "Electronics"
                        },
                        new
                        {
                            CategoryId = new Guid("4d0e5558-b897-4b8e-8754-9f4899719923"),
                            Name = "Clothing"
                        },
                        new
                        {
                            CategoryId = new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"),
                            Name = "Kitchen"
                        });
                });

            modelBuilder.Entity("NudeApp.Models.HighValueItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("HighValueItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed83b44a-c141-4ea1-957f-9139888c54eb"),
                            CategoryId = new Guid("bdf8686d-0fac-466e-9ac8-9bb73dc9db60"),
                            Name = "TV",
                            Value = 2000m
                        },
                        new
                        {
                            Id = new Guid("38a4d2d5-74e7-47c9-8ca2-a1b0127ab313"),
                            CategoryId = new Guid("bdf8686d-0fac-466e-9ac8-9bb73dc9db60"),
                            Name = "Playstation",
                            Value = 400m
                        },
                        new
                        {
                            Id = new Guid("20903f7a-8d20-47fe-8598-e9c5eb35bc1c"),
                            CategoryId = new Guid("bdf8686d-0fac-466e-9ac8-9bb73dc9db60"),
                            Name = "Stereo",
                            Value = 1600m
                        },
                        new
                        {
                            Id = new Guid("8e31483d-ca49-46fd-a290-e0f1ccd6d1d4"),
                            CategoryId = new Guid("4d0e5558-b897-4b8e-8754-9f4899719923"),
                            Name = "Shirts",
                            Value = 1100m
                        },
                        new
                        {
                            Id = new Guid("fba4f3de-2879-4190-a5fd-c105f5dd0030"),
                            CategoryId = new Guid("4d0e5558-b897-4b8e-8754-9f4899719923"),
                            Name = "Jeans",
                            Value = 1100m
                        },
                        new
                        {
                            Id = new Guid("da700c43-0f53-46d3-8dd4-8ec120645f12"),
                            CategoryId = new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"),
                            Name = "Pots and Pans",
                            Value = 3000m
                        },
                        new
                        {
                            Id = new Guid("335d5ace-b761-4e12-974f-a04982d870d5"),
                            CategoryId = new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"),
                            Name = "Flatware",
                            Value = 500m
                        },
                        new
                        {
                            Id = new Guid("3222fd20-eeb7-4885-8cb8-213e69e0c942"),
                            CategoryId = new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"),
                            Name = "Knife Set",
                            Value = 500m
                        },
                        new
                        {
                            Id = new Guid("f16f4e68-17c9-4ba0-9e89-07da8f140501"),
                            CategoryId = new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"),
                            Name = "Misc",
                            Value = 1000m
                        });
                });

            modelBuilder.Entity("NudeApp.Models.HighValueItem", b =>
                {
                    b.HasOne("NudeApp.Models.Category", "Category")
                        .WithMany("HighValueItem")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
