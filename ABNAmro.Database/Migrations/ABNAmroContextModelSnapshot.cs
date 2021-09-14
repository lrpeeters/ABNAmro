﻿// <auto-generated />
using System;
using ABNAmro.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABNAmro.Database.Migrations
{
    [DbContext(typeof(ABNAmroContext))]
    partial class ABNAmroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABNAmro.Domain.Calculations.Calculation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Input1")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Input2")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CreatedAt")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Calculations");
                });

            modelBuilder.Entity("ABNAmro.Domain.Progresses.Progress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalculationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CalculationResult")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Percentage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CalculationId");

                    b.HasIndex("CreatedAt")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Progresses");
                });

            modelBuilder.Entity("ABNAmro.Domain.Progresses.Progress", b =>
                {
                    b.HasOne("ABNAmro.Domain.Calculations.Calculation", "Calculation")
                        .WithMany("Progresses")
                        .HasForeignKey("CalculationId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
