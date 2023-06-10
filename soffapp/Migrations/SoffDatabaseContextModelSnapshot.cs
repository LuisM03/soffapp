﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using soffapp.Models;

#nullable disable

namespace soffapp.Migrations
{
    [DbContext(typeof(SoffDatabaseContext))]
    partial class SoffDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("soffapp.Models.AsociacionProducto", b =>
                {
                    b.Property<long>("IdAsociacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_asociacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdAsociacion"));

                    b.Property<long>("IdDetalleInsumo")
                        .HasColumnType("bigint")
                        .HasColumnName("id_detalle_insumo");

                    b.Property<long>("IdProducto")
                        .HasColumnType("bigint")
                        .HasColumnName("id_producto");

                    b.HasKey("IdAsociacion");

                    b.HasIndex("IdDetalleInsumo");

                    b.HasIndex("IdProducto");

                    b.ToTable("asociacion_producto", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.Compra", b =>
                {
                    b.Property<long>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_compra");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCompra"));

                    b.Property<bool?>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaCompra")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_compra");

                    b.Property<long?>("IdProveedor")
                        .HasColumnType("bigint")
                        .HasColumnName("id_proveedor");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("total");

                    b.HasKey("IdCompra");

                    b.ToTable("compra", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.DetalleInsumo", b =>
                {
                    b.Property<long>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_detalle");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdDetalle"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<long>("IdInsumo")
                        .HasColumnType("bigint")
                        .HasColumnName("id_insumo");

                    b.Property<string>("Medida")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("medida");

                    b.HasKey("IdDetalle");

                    b.HasIndex("IdInsumo");

                    b.ToTable("detalle_insumo", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.Insumo", b =>
                {
                    b.Property<long>("IdInsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_insumo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdInsumo"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaCaducidad")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_caducidad");

                    b.Property<string>("Medida")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("medida");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("precio");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.HasKey("IdInsumo");

                    b.ToTable("insumo", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.Orden", b =>
                {
                    b.Property<long>("IdOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_orden");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdOrden"));

                    b.Property<long?>("IdProducto")
                        .HasColumnType("bigint")
                        .HasColumnName("id_producto");

                    b.Property<long?>("IdVenta")
                        .HasColumnType("bigint")
                        .HasColumnName("id_venta");

                    b.Property<decimal?>("PrecioUnitario")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("precio_unitario");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("total");

                    b.HasKey("IdOrden");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdVenta");

                    b.ToTable("orden", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.OrdenCompra", b =>
                {
                    b.Property<long>("IdOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_orden");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdOrden"));

                    b.Property<string>("Cantidad")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("cantidad")
                        .IsFixedLength();

                    b.Property<long?>("IdCompra")
                        .HasColumnType("bigint")
                        .HasColumnName("id_compra");

                    b.Property<long?>("IdInsumo")
                        .HasColumnType("bigint")
                        .HasColumnName("id_insumo");

                    b.Property<decimal?>("PrecioUnitario")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("precio_unitario");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("total");

                    b.HasKey("IdOrden");

                    b.HasIndex("IdCompra");

                    b.HasIndex("IdInsumo");

                    b.ToTable("orden_compra", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.Producto", b =>
                {
                    b.Property<long>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_producto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdProducto"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("precio");

                    b.HasKey("IdProducto")
                        .HasName("PK_Producto");

                    b.ToTable("producto", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.Proveedor", b =>
                {
                    b.Property<long>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_proveedor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdProveedor"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ciudad");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("correo");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("direccion");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("empresa");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_registro");

                    b.Property<long>("IdInsumo")
                        .HasColumnType("bigint")
                        .HasColumnName("id_insumo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("telefono");

                    b.HasKey("IdProveedor");

                    b.HasIndex("IdInsumo");

                    b.ToTable("proveedor", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.Ventum", b =>
                {
                    b.Property<long>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_venta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdVenta"));

                    b.Property<DateTime?>("FechaVenta")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_venta");

                    b.Property<long?>("Metodo")
                        .HasColumnType("bigint")
                        .HasColumnName("metodo");

                    b.Property<string>("TipoVenta")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipo_venta");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("total");

                    b.HasKey("IdVenta");

                    b.ToTable("venta", (string)null);
                });

            modelBuilder.Entity("soffapp.Models.AsociacionProducto", b =>
                {
                    b.HasOne("soffapp.Models.DetalleInsumo", "IdDetalleInsumoNavigation")
                        .WithMany("AsociacionProductos")
                        .HasForeignKey("IdDetalleInsumo")
                        .IsRequired()
                        .HasConstraintName("FK_asociacion_producto_detalle_insumo");

                    b.HasOne("soffapp.Models.Producto", "IdProductoNavigation")
                        .WithMany("AsociacionProductos")
                        .HasForeignKey("IdProducto")
                        .IsRequired()
                        .HasConstraintName("FK_asociacion_producto_Producto");

                    b.Navigation("IdDetalleInsumoNavigation");

                    b.Navigation("IdProductoNavigation");
                });

            modelBuilder.Entity("soffapp.Models.DetalleInsumo", b =>
                {
                    b.HasOne("soffapp.Models.Insumo", "IdInsumoNavigation")
                        .WithMany("DetalleInsumos")
                        .HasForeignKey("IdInsumo")
                        .IsRequired()
                        .HasConstraintName("FK_detalle_insumo_insumo1");

                    b.Navigation("IdInsumoNavigation");
                });

            modelBuilder.Entity("soffapp.Models.Orden", b =>
                {
                    b.HasOne("soffapp.Models.Producto", "IdProductoNavigation")
                        .WithMany("Ordens")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK_orden_Producto");

                    b.HasOne("soffapp.Models.Ventum", "IdVentaNavigation")
                        .WithMany("Ordens")
                        .HasForeignKey("IdVenta")
                        .HasConstraintName("FK_orden_venta");

                    b.Navigation("IdProductoNavigation");

                    b.Navigation("IdVentaNavigation");
                });

            modelBuilder.Entity("soffapp.Models.OrdenCompra", b =>
                {
                    b.HasOne("soffapp.Models.Compra", "IdCompraNavigation")
                        .WithMany("OrdenCompras")
                        .HasForeignKey("IdCompra")
                        .HasConstraintName("FK_orden_compra_compra");

                    b.HasOne("soffapp.Models.Insumo", "IdInsumoNavigation")
                        .WithMany("OrdenCompras")
                        .HasForeignKey("IdInsumo")
                        .HasConstraintName("FK_orden_compra_insumo");

                    b.Navigation("IdCompraNavigation");

                    b.Navigation("IdInsumoNavigation");
                });

            modelBuilder.Entity("soffapp.Models.Proveedor", b =>
                {
                    b.HasOne("soffapp.Models.Insumo", "IdInsumoNavigation")
                        .WithMany("Proveedors")
                        .HasForeignKey("IdInsumo")
                        .IsRequired()
                        .HasConstraintName("FK_proveedor_insumo");

                    b.Navigation("IdInsumoNavigation");
                });

            modelBuilder.Entity("soffapp.Models.Compra", b =>
                {
                    b.Navigation("OrdenCompras");
                });

            modelBuilder.Entity("soffapp.Models.DetalleInsumo", b =>
                {
                    b.Navigation("AsociacionProductos");
                });

            modelBuilder.Entity("soffapp.Models.Insumo", b =>
                {
                    b.Navigation("DetalleInsumos");

                    b.Navigation("OrdenCompras");

                    b.Navigation("Proveedors");
                });

            modelBuilder.Entity("soffapp.Models.Producto", b =>
                {
                    b.Navigation("AsociacionProductos");

                    b.Navigation("Ordens");
                });

            modelBuilder.Entity("soffapp.Models.Ventum", b =>
                {
                    b.Navigation("Ordens");
                });
#pragma warning restore 612, 618
        }
    }
}
