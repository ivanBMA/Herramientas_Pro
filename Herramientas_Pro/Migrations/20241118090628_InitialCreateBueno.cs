using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herramientas_Pro.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateBueno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Zanca",
                table: "Entradas_Salidas",
                newName: "Unidad");

            migrationBuilder.RenameColumn(
                name: "Vidrios",
                table: "Entradas_Salidas",
                newName: "Producto");

            migrationBuilder.RenameColumn(
                name: "Tornilleria",
                table: "Entradas_Salidas",
                newName: "Firma");

            migrationBuilder.RenameColumn(
                name: "Proyecto",
                table: "Entradas_Salidas",
                newName: "Codigo");

            migrationBuilder.AddColumn<double>(
                name: "Cantidad",
                table: "Entradas_Salidas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Entradas_Salidas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Entradas_Salidas");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Entradas_Salidas");

            migrationBuilder.RenameColumn(
                name: "Unidad",
                table: "Entradas_Salidas",
                newName: "Zanca");

            migrationBuilder.RenameColumn(
                name: "Producto",
                table: "Entradas_Salidas",
                newName: "Vidrios");

            migrationBuilder.RenameColumn(
                name: "Firma",
                table: "Entradas_Salidas",
                newName: "Tornilleria");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Entradas_Salidas",
                newName: "Proyecto");

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
        }
    }
}
