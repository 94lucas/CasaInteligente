﻿// <auto-generated />
using System;
using CasaInteligente.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CasaInteligente.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240629180407_correcaoEvento")]
    partial class correcaoEvento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CasaInteligente.Models.CasaModel", b =>
                {
                    b.Property<int>("CasaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CasaId"));

                    b.Property<int>("Cep")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("CasaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Casas", (string)null);
                });

            modelBuilder.Entity("CasaInteligente.Models.DispositivoSegModel", b =>
                {
                    b.Property<int>("DispositivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DispositivoId"));

                    b.Property<int>("CasaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("EventoDeEmergenciaModelEventoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EventoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("LocalInstalacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.HasKey("DispositivoId");

                    b.HasIndex("CasaId");

                    b.HasIndex("EventoDeEmergenciaModelEventoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Dispositivos", (string)null);
                });

            modelBuilder.Entity("CasaInteligente.Models.EventoDeEmergenciaModel", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventoId"));

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("DATE");

                    b.Property<int>("DispositivoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos", (string)null);
                });

            modelBuilder.Entity("CasaInteligente.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR2(60)");

                    b.Property<long?>("Telefone")
                        .HasColumnType("NUMBER(11)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("CasaInteligente.Models.CasaModel", b =>
                {
                    b.HasOne("CasaInteligente.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CasaInteligente.Models.DispositivoSegModel", b =>
                {
                    b.HasOne("CasaInteligente.Models.CasaModel", "Casa")
                        .WithMany()
                        .HasForeignKey("CasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CasaInteligente.Models.EventoDeEmergenciaModel", null)
                        .WithMany("Dispositivos")
                        .HasForeignKey("EventoDeEmergenciaModelEventoId");

                    b.HasOne("CasaInteligente.Models.EventoDeEmergenciaModel", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Casa");

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("CasaInteligente.Models.EventoDeEmergenciaModel", b =>
                {
                    b.Navigation("Dispositivos");
                });
#pragma warning restore 612, 618
        }
    }
}
