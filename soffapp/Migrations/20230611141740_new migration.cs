using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soffapp.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orden");

            migrationBuilder.CreateTable(
                name: "orden_venta",
                columns: table => new
                {
                    id_orden = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_venta = table.Column<long>(type: "bigint", nullable: false),
                    id_producto = table.Column<long>(type: "bigint", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    importe = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_venta", x => x.id_orden);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orden_venta");

            migrationBuilder.CreateTable(
                name: "orden",
                columns: table => new
                {
                    id_orden = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto = table.Column<long>(type: "bigint", nullable: true),
                    id_venta = table.Column<long>(type: "bigint", nullable: true),
                    precio_unitario = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(16,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden", x => x.id_orden);
                    table.ForeignKey(
                        name: "FK_orden_Producto",
                        column: x => x.id_producto,
                        principalTable: "producto",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "FK_orden_venta",
                        column: x => x.id_venta,
                        principalTable: "venta",
                        principalColumn: "id_venta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_orden_id_producto",
                table: "orden",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_orden_id_venta",
                table: "orden",
                column: "id_venta");
        }
    }
}
