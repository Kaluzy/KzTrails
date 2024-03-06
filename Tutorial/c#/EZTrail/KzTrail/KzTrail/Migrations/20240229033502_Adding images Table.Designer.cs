﻿// <auto-generated />
using System;
using KzTrail.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KzTrail.Migrations
{
    [DbContext(typeof(KzTrailDbContext))]
    [Migration("20240229033502_Adding images Table")]
    partial class AddingimagesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KzTrail.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f81ec6f-c675-4838-a967-4964b48d9b19"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("175e8a13-362f-4def-8a10-a8341433721f"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("e3b6933e-319f-4a06-bc58-3e6c9f5baddf"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("KzTrail.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FildDescripion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("KzTrail.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                            Code = "CA",
                            Name = "California",
                            RegionImageUrl = "california-img-url.jpg"
                        },
                        new
                        {
                            Id = new Guid("1a39d5f9-a70c-45e9-b61b-8fe1b964286b"),
                            Code = "DE",
                            Name = "Delaware",
                            RegionImageUrl = "delaware-img-url.jpg"
                        },
                        new
                        {
                            Id = new Guid("a23ea3b9-47c4-4e82-a8f7-9d2f42a0c46d"),
                            Code = "IL",
                            Name = "Illionois",
                            RegionImageUrl = "illionois-img-url.jpg"
                        },
                        new
                        {
                            Id = new Guid("d52fa863-033f-410f-8516-1da939891ac9"),
                            Code = "KS",
                            Name = "Kansas",
                            RegionImageUrl = "kansas-img-url.jpg"
                        });
                });

            modelBuilder.Entity("KzTrail.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripiton")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("KzTrail.Models.Domain.Walk", b =>
                {
                    b.HasOne("KzTrail.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KzTrail.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
