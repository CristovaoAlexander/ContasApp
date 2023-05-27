﻿// <auto-generated />
using System;
using ContasApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContasApp.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230516001827_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContasApp.Data.Entities.Categoria", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("TIPO");

                    b.Property<Guid?>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USUARIO_ID");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CATEGORIA", (string)null);
                });

            modelBuilder.Entity("ContasApp.Data.Entities.Conta", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid?>("CategoriaId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CATEGORIA_ID");

                    b.Property<DateTime?>("Data")
                        .IsRequired()
                        .HasColumnType("date")
                        .HasColumnName("DATA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("OBSERVACOES");

                    b.Property<Guid?>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USUARIO_ID");

                    b.Property<decimal?>("Valor")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("VALOR");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CONTA", (string)null);
                });

            modelBuilder.Entity("ContasApp.Data.Entities.Usuario", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("SENHA");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("ContasApp.Data.Entities.Categoria", b =>
                {
                    b.HasOne("ContasApp.Data.Entities.Usuario", "Usuario")
                        .WithMany("Categorias")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ContasApp.Data.Entities.Conta", b =>
                {
                    b.HasOne("ContasApp.Data.Entities.Categoria", "Categoria")
                        .WithMany("Contas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ContasApp.Data.Entities.Usuario", "Usuario")
                        .WithMany("Contas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ContasApp.Data.Entities.Categoria", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("ContasApp.Data.Entities.Usuario", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}
