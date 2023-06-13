using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace soffapp.Models;

public partial class SoffDatabaseContext : DbContext
{
    public SoffDatabaseContext()
    {
    }

    public SoffDatabaseContext(DbContextOptions<SoffDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsociacionProducto> AsociacionProductos { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleInsumo> DetalleInsumos { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<OrdenVentum> OrdenVenta { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=soff_database;integrated security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsociacionProducto>(entity =>
        {
            entity.HasKey(e => e.IdAsociacion);

            entity.ToTable("asociacion_producto");

            entity.Property(e => e.IdAsociacion).HasColumnName("id_asociacion");
            entity.Property(e => e.IdDetalleInsumo).HasColumnName("id_detalle_insumo");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdDetalleInsumoNavigation).WithMany(p => p.AsociacionProductos)
                .HasForeignKey(d => d.IdDetalleInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_asociacion_producto_detalle_insumo");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.AsociacionProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_asociacion_producto_Producto");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra);

            entity.ToTable("compra");

            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("datetime")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<DetalleInsumo>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("detalle_insumo");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdInsumo).HasColumnName("id_insumo");
            entity.Property(e => e.Medida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("medida");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleInsumos)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_insumo_insumo1");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo);

            entity.ToTable("insumo");

            entity.Property(e => e.IdInsumo).HasColumnName("id_insumo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCaducidad)
                .HasColumnType("datetime")
                .HasColumnName("fecha_caducidad");
            entity.Property(e => e.Medida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("medida");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrden);

            entity.ToTable("orden_compra");

            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cantidad");
            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.IdInsumo).HasColumnName("id_insumo");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK_orden_compra_compra");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.IdInsumo)
                .HasConstraintName("FK_orden_compra_insumo");
        });

        modelBuilder.Entity<OrdenVentum>(entity =>
        {
            entity.HasKey(e => e.IdOrden);

            entity.ToTable("orden_venta");

            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Importe)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("importe");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("precio_unitario");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_Producto");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor);

            entity.ToTable("proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Empresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empresa");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdInsumo).HasColumnName("id_insumo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_proveedor_insumo");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.ToTable("venta");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("datetime")
                .HasColumnName("fecha_venta");
            entity.Property(e => e.Metodo).HasColumnName("metodo");
            entity.Property(e => e.TipoVenta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_venta");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
