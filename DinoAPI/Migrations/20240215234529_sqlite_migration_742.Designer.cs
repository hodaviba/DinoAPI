﻿// <auto-generated />
using System;
using DinoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DinoAPI.Migrations
{
    [DbContext(typeof(DinoAPIContext))]
    [Migration("20240215234529_sqlite_migration_742")]
    partial class sqlite_migration_742
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("DinoAPI.Models.Dino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Diet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Era")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("Height")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Dino");
                });
#pragma warning restore 612, 618
        }
    }
}
