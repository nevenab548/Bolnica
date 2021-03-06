﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Models;

namespace Server.Migrations
{
    [DbContext(typeof(BolnicaContext))]
    [Migration("20210110143706_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Server.Models.Bolnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("BrojSoba")
                        .HasColumnType("int")
                        .HasColumnName("BrojSoba");

                    b.Property<int>("KapacitetSobe")
                        .HasColumnType("int")
                        .HasColumnName("KapacitetSobe");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.Property<int>("USmeni")
                        .HasColumnType("int")
                        .HasColumnName("Usmeni");

                    b.HasKey("ID");

                    b.ToTable("Bolnica");
                });

            modelBuilder.Entity("Server.Models.Lekar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int?>("BolnicaID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Ime");

                    b.Property<string>("Prezime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Prezime");

                    b.HasKey("ID");

                    b.HasIndex("BolnicaID");

                    b.ToTable("Lekar");
                });

            modelBuilder.Entity("Server.Models.Smena", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int?>("BolnicaID")
                        .HasColumnType("int");

                    b.Property<int>("Broj")
                        .HasColumnType("int")
                        .HasColumnName("Broj");

                    b.Property<int>("BrojSmene")
                        .HasColumnType("int")
                        .HasColumnName("BrojSmene");

                    b.Property<string>("Lekar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Lekar");

                    b.HasKey("ID");

                    b.HasIndex("BolnicaID");

                    b.ToTable("Smena");
                });

            modelBuilder.Entity("Server.Models.Soba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int?>("BolnicaID")
                        .HasColumnType("int");

                    b.Property<int>("BrojSobe")
                        .HasColumnType("int")
                        .HasColumnName("BrojSobe");

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

                    b.HasKey("ID");

                    b.HasIndex("BolnicaID");

                    b.ToTable("Soba");
                });

            modelBuilder.Entity("Server.Models.Lekar", b =>
                {
                    b.HasOne("Server.Models.Bolnica", "Bolnica")
                        .WithMany("Lekari")
                        .HasForeignKey("BolnicaID");

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("Server.Models.Smena", b =>
                {
                    b.HasOne("Server.Models.Bolnica", "Bolnica")
                        .WithMany("Smene")
                        .HasForeignKey("BolnicaID");

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("Server.Models.Soba", b =>
                {
                    b.HasOne("Server.Models.Bolnica", "Bolnica")
                        .WithMany("Sobe")
                        .HasForeignKey("BolnicaID");

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("Server.Models.Bolnica", b =>
                {
                    b.Navigation("Lekari");

                    b.Navigation("Smene");

                    b.Navigation("Sobe");
                });
#pragma warning restore 612, 618
        }
    }
}
