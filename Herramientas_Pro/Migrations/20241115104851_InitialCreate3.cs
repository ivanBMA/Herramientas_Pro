using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herramientas_Pro.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diseño_Inicial",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Fimra",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Medicion",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Nube_Puntos",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Otros",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Presupuestos",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Responsable",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Cantidad_Minima",
                table: "Inventario",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Codigo_Producto",
                table: "Inventario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comprar",
                table: "Inventario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producto",
                table: "Inventario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unidad",
                table: "Inventario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unidad2",
                table: "Inventario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "stock",
                table: "Inventario",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Baranda",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diseño",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Guia",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Montajes",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Peldaños",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plotters",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Proyecto",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tornilleria",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vidrio",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zancas",
                table: "Fabricacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Baranda",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diseño",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Guia",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Montajes",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Peldaños",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plotters",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Proyecto",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tornilleria",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vidrios",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zanca",
                table: "Entradas_Salidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Arreglos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Responsable",
                table: "Arreglos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Diseño_Inicial",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Fimra",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Medicion",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Nube_Puntos",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Otros",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Presupuestos",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Responsable",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Cantidad_Minima",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Codigo_Producto",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Comprar",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Producto",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Unidad",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Unidad2",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "stock",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Baranda",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Diseño",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Guia",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Montajes",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Peldaños",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Plotters",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Proyecto",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Tornilleria",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Vidrio",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Zancas",
                table: "Fabricacion");

            migrationBuilder.DropColumn(
                name: "Baranda",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Diseño",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Guia",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Montajes",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Peldaños",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Plotters",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Proyecto",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Tornilleria",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Vidrios",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Zanca",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Arreglos");

            migrationBuilder.DropColumn(
                name: "Responsable",
                table: "Arreglos");
        }
    }
}
