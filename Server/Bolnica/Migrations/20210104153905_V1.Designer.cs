﻿// <auto-generated />
using System;
using Bolnica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bolnica.Migrations
{
    [DbContext(typeof(BolnicaContext))]
    [Migration("20210104153905_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Bolnica.Models.Bolnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("BrojSmena")
                        .HasColumnType("int")
                        .HasColumnName("BrojSmena");

                    b.Property<int>("BrojSoba")
                        .HasColumnType("int")
                        .HasColumnName("BrojSoba");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("Bolnica");
                });

            modelBuilder.Entity("Bolnica.Models.Smena", b =>
                {
                    b.Property<int>("BrojSmene")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BrojSmene")
                        .UseIdentityColumn();

                    b.Property<int?>("BolnicaID")
                        .HasColumnType("int");

                    b.Property<int>("Broj")
                        .HasColumnType("int")
                        .HasColumnName("Broj");

                    b.Property<string>("Lekar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Lekar");

                    b.HasKey("BrojSmene");

                    b.HasIndex("BolnicaID");

                    b.ToTable("Smene");
                });

            modelBuilder.Entity("Bolnica.Models.Soba", b =>
                {
                    b.Property<int>("BrojSobe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Broj sobe")
                        .UseIdentityColumn();

                    b.Property<int?>("BolnicaID")
                        .HasColumnType("int");

                    b.Property<bool>("Hitno")
                        .HasColumnType("bit")
                        .HasColumnName("Hitno");

                    b.Property<int>("MaxPrimljeni")
                        .HasColumnType("int")
                        .HasColumnName("MaxPrimljeni");

                    b.Property<string>("Odelenje")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Odelenje");

                    b.Property<string>("Pacijenti")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Pacijenti");

                    b.Property<int>("Primljeni")
                        .HasColumnType("int")
                        .HasColumnName("Primljeni");

                    b.HasKey("BrojSobe");

                    b.HasIndex("BolnicaID");

                    b.ToTable("Soba");
                });

            modelBuilder.Entity("Bolnica.Models.Smena", b =>
                {
                    b.HasOne("Bolnica.Models.Bolnica", "Bolnica")
                        .WithMany("Smene")
                        .HasForeignKey("BolnicaID");

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("Bolnica.Models.Soba", b =>
                {
                    b.HasOne("Bolnica.Models.Bolnica", "Bolnica")
                        .WithMany("Sobe")
                        .HasForeignKey("BolnicaID");

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("Bolnica.Models.Bolnica", b =>
                {
                    b.Navigation("Smene");

                    b.Navigation("Sobe");
                });
#pragma warning restore 612, 618
        }
    }
}
