﻿// <auto-generated />
using System;
using Herramientas_Pro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Herramientas_Pro.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241119124021_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Herramientas_Pro.Models.Arreglos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Baranda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cita")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diseño")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Guia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Montajes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Otros")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Peldaños")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proyecto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tornilleria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vidrios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zancas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Arreglos");
                });

            modelBuilder.Entity("Herramientas_Pro.Models.Entradas_Salidas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entradas_Salidas");
                });

            modelBuilder.Entity("Herramientas_Pro.Models.Fabricacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Baranda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diseño")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Montajes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Peldaños")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plotters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proyecto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tornilleria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vidrio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zancas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fabricacion");
                });

            modelBuilder.Entity("Herramientas_Pro.Models.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Cantidad_Minima")
                        .HasColumnType("float");

                    b.Property<string>("Codigo_Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comprar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unidad2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("stock")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("Herramientas_Pro.Models.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diseño_Inicial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fimra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Nube_Puntos")
                        .HasColumnType("bit");

                    b.Property<string>("Otros")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Presupuestos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Herramientas_Pro.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cantidad_Minima")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo_Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Coste_Unidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
