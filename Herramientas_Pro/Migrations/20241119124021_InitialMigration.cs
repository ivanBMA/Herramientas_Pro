using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herramientas_Pro.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arreglos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proyecto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diseño = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vidrios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Baranda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zancas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montajes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peldaños = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tornilleria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arreglos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entradas_Salidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas_Salidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proyecto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diseño = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vidrio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Baranda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zancas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montajes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plotters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peldaños = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tornilleria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<double>(type: "float", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad_Minima = table.Column<double>(type: "float", nullable: false),
                    Unidad2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comprar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Presupuestos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nube_Puntos = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diseño_Inicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fimra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad_Minima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coste_Unidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arreglos");

            migrationBuilder.DropTable(
                name: "Entradas_Salidas");

            migrationBuilder.DropTable(
                name: "Fabricacion");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
