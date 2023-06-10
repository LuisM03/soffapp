using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soffapp.Migrations
{
    /// <inheritdoc />
    public partial class NewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orden_id_producto",
                table: "orden",
                column: "id_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_orden_Producto",
                table: "orden",
                column: "id_producto",
                principalTable: "producto",
                principalColumn: "id_producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orden_Producto",
                table: "orden");

            migrationBuilder.DropIndex(
                name: "IX_orden_id_producto",
                table: "orden");
        }
    }
}
