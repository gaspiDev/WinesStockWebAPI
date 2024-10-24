﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(WinesStockContext))]
    [Migration("20241012215622_WineEntityHotFix")]
    partial class WineEntityHotFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Entities.Wine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Variety")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Wines");
                });

            modelBuilder.Entity("Data.Entities.WineTasting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Guests")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WineTastings");
                });

            modelBuilder.Entity("Data.Entities.WineTastingWine", b =>
                {
                    b.Property<int>("WineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WineTastingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("WineId", "WineTastingId");

                    b.HasIndex("WineTastingId");

                    b.ToTable("WineTastingWines");
                });

            modelBuilder.Entity("Data.Entities.WineTastingWine", b =>
                {
                    b.HasOne("Data.Entities.Wine", "Wine")
                        .WithMany("WineTastingWines")
                        .HasForeignKey("WineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.WineTasting", "WineTasting")
                        .WithMany("WineTastingWines")
                        .HasForeignKey("WineTastingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wine");

                    b.Navigation("WineTasting");
                });

            modelBuilder.Entity("Data.Entities.Wine", b =>
                {
                    b.Navigation("WineTastingWines");
                });

            modelBuilder.Entity("Data.Entities.WineTasting", b =>
                {
                    b.Navigation("WineTastingWines");
                });
#pragma warning restore 612, 618
        }
    }
}
