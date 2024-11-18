﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herramientas_Pro.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateBuena2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unidad",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidad",
                table: "Productos");
        }
    }
}
