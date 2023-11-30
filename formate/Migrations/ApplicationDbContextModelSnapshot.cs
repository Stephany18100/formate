﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using formate.Context;

#nullable disable

namespace formate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("formate.Models.Entities.Cliente", b =>
                {
                    b.Property<int>("PkCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkCliente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkCliente");

                    b.HasIndex("FkRol");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("formate.Models.Entities.Comentario", b =>
                {
                    b.Property<int>("PkComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkComentario"));

                    b.Property<int>("ClientesPkCliente")
                        .HasColumnType("int");

                    b.Property<int?>("FkCliente")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkComentario");

                    b.HasIndex("ClientesPkCliente");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("formate.Models.Entities.Rol", b =>
                {
                    b.Property<int>("PkRoles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRoles"));

                    b.Property<string>("Nombrerol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRoles");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            PkRoles = 1,
                            Nombrerol = "admin"
                        },
                        new
                        {
                            PkRoles = 2,
                            Nombrerol = "sa"
                        });
                });

            modelBuilder.Entity("formate.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkUsuario"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FkRol")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NombreUsu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            PkUsuario = 1,
                            Contrasena = "1234",
                            FkRol = 1,
                            NombreUsu = "Maria Jose"
                        });
                });

            modelBuilder.Entity("formate.Models.Entities.Cliente", b =>
                {
                    b.HasOne("formate.Models.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("formate.Models.Entities.Comentario", b =>
                {
                    b.HasOne("formate.Models.Entities.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesPkCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("formate.Models.Entities.Usuario", b =>
                {
                    b.HasOne("formate.Models.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}