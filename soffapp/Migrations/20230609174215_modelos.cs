using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soffapp.Migrations
{
    /// <inheritdoc />
    public partial class modelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    id_compra = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_compra = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_proveedor = table.Column<long>(type: "bigint", nullable: true),
                    total = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra", x => x.id_compra);
                });

            migrationBuilder.CreateTable(
                name: "insumo",
                columns: table => new
                {
                    id_insumo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha_caducidad = table.Column<DateTime>(type: "datetime", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    medida = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumo", x => x.id_insumo);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id_producto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id_producto);
                });

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    id_venta = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_venta = table.Column<DateTime>(type: "datetime", nullable: true),
                    metodo = table.Column<long>(type: "bigint", nullable: true),
                    total = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    tipo_venta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.id_venta);
                });

            migrationBuilder.CreateTable(
                name: "detalle_insumo",
                columns: table => new
                {
                    id_detalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_insumo = table.Column<long>(type: "bigint", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    medida = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_insumo", x => x.id_detalle);
                    table.ForeignKey(
                        name: "FK_detalle_insumo_insumo1",
                        column: x => x.id_insumo,
                        principalTable: "insumo",
                        principalColumn: "id_insumo");
                });

            migrationBuilder.CreateTable(
                name: "orden_compra",
                columns: table => new
                {
                    id_orden = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_compra = table.Column<long>(type: "bigint", nullable: true),
                    id_insumo = table.Column<long>(type: "bigint", nullable: true),
                    cantidad = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    precio_unitario = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(16,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_compra", x => x.id_orden);
                    table.ForeignKey(
                        name: "FK_orden_compra_compra",
                        column: x => x.id_compra,
                        principalTable: "compra",
                        principalColumn: "id_compra");
                    table.ForeignKey(
                        name: "FK_orden_compra_insumo",
                        column: x => x.id_insumo,
                        principalTable: "insumo",
                        principalColumn: "id_insumo");
                });

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    id_proveedor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_insumo = table.Column<long>(type: "bigint", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    empresa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime", nullable: false),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ciudad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.id_proveedor);
                    table.ForeignKey(
                        name: "FK_proveedor_insumo",
                        column: x => x.id_insumo,
                        principalTable: "insumo",
                        principalColumn: "id_insumo");
                });

            migrationBuilder.CreateTable(
                name: "orden",
                columns: table => new
                {
                    id_orden = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_venta = table.Column<long>(type: "bigint", nullable: true),
                    id_producto = table.Column<long>(type: "bigint", nullable: true),
                    precio_unitario = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(16,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden", x => x.id_orden);
                    table.ForeignKey(
                        name: "FK_orden_venta",
                        column: x => x.id_venta,
                        principalTable: "venta",
                        principalColumn: "id_venta");
                });

            migrationBuilder.CreateTable(
                name: "asociacion_producto",
                columns: table => new
                {
                    id_asociacion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_detalle_insumo = table.Column<long>(type: "bigint", nullable: false),
                    id_producto = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asociacion_producto", x => x.id_asociacion);
                    table.ForeignKey(
                        name: "FK_asociacion_producto_Producto",
                        column: x => x.id_producto,
                        principalTable: "producto",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "FK_asociacion_producto_detalle_insumo",
                        column: x => x.id_detalle_insumo,
                        principalTable: "detalle_insumo",
                        principalColumn: "id_detalle");
                });

            migrationBuilder.CreateIndex(
                name: "IX_asociacion_producto_id_detalle_insumo",
                table: "asociacion_producto",
                column: "id_detalle_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_asociacion_producto_id_producto",
                table: "asociacion_producto",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_insumo_id_insumo",
                table: "detalle_insumo",
                column: "id_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_orden_id_venta",
                table: "orden",
                column: "id_venta");

            migrationBuilder.CreateIndex(
                name: "IX_orden_compra_id_compra",
                table: "orden_compra",
                column: "id_compra");

            migrationBuilder.CreateIndex(
                name: "IX_orden_compra_id_insumo",
                table: "orden_compra",
                column: "id_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_id_insumo",
                table: "proveedor",
                column: "id_insumo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asociacion_producto");

            migrationBuilder.DropTable(
                name: "orden");

            migrationBuilder.DropTable(
                name: "orden_compra");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "detalle_insumo");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "insumo");
        }
    }
}
