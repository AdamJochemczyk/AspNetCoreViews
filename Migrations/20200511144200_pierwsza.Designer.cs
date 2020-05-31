﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using zaj9.Models;

namespace zaj9.Migrations
{
    [DbContext(typeof(ProbkiDb))]
    [Migration("20200511144200_pierwsza")]
    partial class pierwsza
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("zaj9.Models.Probki", b =>
                {
                    b.Property<int>("IdBadania")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdBadania")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ilosc_Pojemnikow")
                        .HasColumnType("int")
                        .HasMaxLength(3);

                    b.Property<string>("Nazwa_Probki")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<double>("Waga_Probek")
                        .HasColumnType("float")
                        .HasMaxLength(3);

                    b.Property<bool>("zbadane")
                        .HasColumnType("bit");

                    b.HasKey("IdBadania");

                    b.ToTable("Probki");
                });
#pragma warning restore 612, 618
        }
    }
}