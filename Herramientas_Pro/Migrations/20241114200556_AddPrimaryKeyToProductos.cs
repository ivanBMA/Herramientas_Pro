using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herramientas_Pro.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyToProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad_Minima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "Productos");
        }
    }
}
