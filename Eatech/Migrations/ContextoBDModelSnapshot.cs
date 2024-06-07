﻿// <auto-generated />
using System;
using Eatech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eatech.Migrations
{
    [DbContext(typeof(ContextoBD))]
    partial class ContextoBDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Eatech.Models.Bd_Alumno", b =>
                {
                    b.Property<Guid>("IdAlumno")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alergias")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Enfermedades")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("GradoEscolar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasMaxLength(528)
                        .HasColumnType("nvarchar(528)");

                    b.Property<string>("PreferenciasComida")
                        .IsRequired()
                        .HasMaxLength(528)
                        .HasColumnType("nvarchar(528)");

                    b.Property<string>("aMaterno")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("aPaterno")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IdAlumno");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("Eatech.Models.Bd_Comida", b =>
                {
                    b.Property<Guid>("IDComida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Porciones")
                        .HasColumnType("int");

                    b.Property<int>("PorcionesDisponibles")
                        .HasColumnType("int");

                    b.HasKey("IDComida");

                    b.ToTable("Comidas");
                });

            modelBuilder.Entity("Eatech.Models.Bd_Escuela", b =>
                {
                    b.Property<Guid>("IdEscuela")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Codigo")
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IdEscuela");

                    b.ToTable("Escuela");
                });

            modelBuilder.Entity("Eatech.Models.Bd_Ingredientes", b =>
                {
                    b.Property<Guid>("IdIngrediente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIngrediente");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("Eatech.Models.Bd_Pedido", b =>
                {
                    b.Property<Guid>("pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCPedido")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("NotaPedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pedido");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Eatech.Models.Bd_Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CaducidadToken")
                        .HasColumnType("datetime2");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TokenDRestauracion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("aMaterno")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("aPaterno")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Alu_Ped", b =>
                {
                    b.Property<Guid>("IdAlumno")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("pedido")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("IdAlumno");

                    b.HasIndex("pedido");

                    b.ToTable("Intermedia_Alum_Pedi");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Com_Ingr", b =>
                {
                    b.Property<Guid>("IDComida")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdIngrediente")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("IDComida");

                    b.HasIndex("IdIngrediente");

                    b.ToTable("Intermedia_Comida_Ingre");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Com_Ped", b =>
                {
                    b.Property<Guid>("IDComida")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("pedido")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("IDComida");

                    b.HasIndex("pedido");

                    b.ToTable("Intermedia_Comida_Pedi");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Usu_Alum", b =>
                {
                    b.Property<Guid>("IdAlumno")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("IdAlumno");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Intermedia_Usuario_Alumno");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Usu_Esc", b =>
                {
                    b.Property<Guid>("IdEscuela")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("IdEscuela");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Intermedia_Usuario_Escuela");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Alu_Ped", b =>
                {
                    b.HasOne("Eatech.Models.Bd_Alumno", "Idalumno")
                        .WithMany()
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eatech.Models.Bd_Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idalumno");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Com_Ingr", b =>
                {
                    b.HasOne("Eatech.Models.Bd_Comida", "IDcomida")
                        .WithMany()
                        .HasForeignKey("IDComida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eatech.Models.Bd_Ingredientes", "Idingrediente")
                        .WithMany()
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IDcomida");

                    b.Navigation("Idingrediente");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Com_Ped", b =>
                {
                    b.HasOne("Eatech.Models.Bd_Comida", "IDcomida")
                        .WithMany()
                        .HasForeignKey("IDComida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eatech.Models.Bd_Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IDcomida");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Usu_Alum", b =>
                {
                    b.HasOne("Eatech.Models.Bd_Alumno", "Idalumno")
                        .WithMany()
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eatech.Models.Bd_Usuario", "IdUsu")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUsu");

                    b.Navigation("Idalumno");
                });

            modelBuilder.Entity("Eatech.Models.BdI_Usu_Esc", b =>
                {
                    b.HasOne("Eatech.Models.Bd_Escuela", "Idescuela")
                        .WithMany()
                        .HasForeignKey("IdEscuela")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eatech.Models.Bd_Usuario", "Idusuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idescuela");

                    b.Navigation("Idusuario");
                });
#pragma warning restore 612, 618
        }
    }
}
