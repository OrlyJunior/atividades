﻿// <auto-generated />
using System;
using Entity2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity2.Migrations
{
    [DbContext(typeof(Entity2Context))]
    partial class Entity2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entity2.Models.Compromisso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContatoId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.HasIndex("LocalId");

                    b.ToTable("Compromisso");
                });

            modelBuilder.Entity("Entity2.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EncapsulamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Fone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EncapsulamentoId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Entity2.Models.Encapsulamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Contato2Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime2");

                    b.Property<int>("Local2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Contato2Id");

                    b.HasIndex("Local2Id");

                    b.ToTable("Encapsulamento");
                });

            modelBuilder.Entity("Entity2.Models.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EncapsulamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EncapsulamentoId");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("Entity2.Models.Compromisso", b =>
                {
                    b.HasOne("Entity2.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity2.Models.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("Local");
                });

            modelBuilder.Entity("Entity2.Models.Contato", b =>
                {
                    b.HasOne("Entity2.Models.Encapsulamento", null)
                        .WithMany("Contato")
                        .HasForeignKey("EncapsulamentoId");
                });

            modelBuilder.Entity("Entity2.Models.Encapsulamento", b =>
                {
                    b.HasOne("Entity2.Models.Contato", "Contato2")
                        .WithMany()
                        .HasForeignKey("Contato2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity2.Models.Local", "Local2")
                        .WithMany()
                        .HasForeignKey("Local2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato2");

                    b.Navigation("Local2");
                });

            modelBuilder.Entity("Entity2.Models.Local", b =>
                {
                    b.HasOne("Entity2.Models.Encapsulamento", null)
                        .WithMany("Local")
                        .HasForeignKey("EncapsulamentoId");
                });

            modelBuilder.Entity("Entity2.Models.Encapsulamento", b =>
                {
                    b.Navigation("Contato");

                    b.Navigation("Local");
                });
#pragma warning restore 612, 618
        }
    }
}
