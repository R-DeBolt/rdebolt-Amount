﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rdebolt_Amount.Data;

#nullable disable

namespace rdebolt_Amount.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("rdebolt_Amount.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DemographicId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DemographicId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("rdebolt_Amount.Models.Demographic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<float>("DebtTotal")
                        .HasColumnType("real");

                    b.Property<int>("Defaults")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Risk")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Demographics");
                });

            modelBuilder.Entity("rdebolt_Amount.Models.Loans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BusinessId")
                        .HasColumnType("int");

                    b.Property<int>("Business_Id")
                        .HasColumnType("int");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.Property<double>("apr")
                        .HasColumnType("float");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("rdebolt_Amount.Models.Business", b =>
                {
                    b.HasOne("rdebolt_Amount.Models.Demographic", null)
                        .WithMany("Business")
                        .HasForeignKey("DemographicId");
                });

            modelBuilder.Entity("rdebolt_Amount.Models.Loans", b =>
                {
                    b.HasOne("rdebolt_Amount.Models.Business", null)
                        .WithMany("Loans")
                        .HasForeignKey("BusinessId");
                });

            modelBuilder.Entity("rdebolt_Amount.Models.Business", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("rdebolt_Amount.Models.Demographic", b =>
                {
                    b.Navigation("Business");
                });
#pragma warning restore 612, 618
        }
    }
}
