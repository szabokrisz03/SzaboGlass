﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SzaboGlass.Data;

#nullable disable

namespace SzaboGlass.Data.Migrations
{
    [DbContext(typeof(Program))]
    [Migration("20240725135106_GlassAndGlassTypeInitialization")]
    partial class GlassAndGlassTypeInitialization
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("SzaboGlass.Data.Entity.Glass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("GlassTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PriceWithVAT")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PurchasePriceCE")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PurchasePriceMalyi")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SerialPrice")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UniquePrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GlassTypeId");

                    b.ToTable("Glasses");
                });

            modelBuilder.Entity("SzaboGlass.Data.Entity.GlassType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GlassTypes");
                });

            modelBuilder.Entity("SzaboGlass.Data.Entity.Glass", b =>
                {
                    b.HasOne("SzaboGlass.Data.Entity.GlassType", "GlassType")
                        .WithMany()
                        .HasForeignKey("GlassTypeId");

                    b.Navigation("GlassType");
                });
#pragma warning restore 612, 618
        }
    }
}
