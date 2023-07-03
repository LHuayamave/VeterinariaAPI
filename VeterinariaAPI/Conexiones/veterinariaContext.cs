using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Conexiones;

public partial class veterinariaContext : DbContext
{
    public veterinariaContext()
    {
    }

    public veterinariaContext(DbContextOptions<veterinariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<TieEmpresa> TieEmpresas { get; set; }

    public virtual DbSet<TieFacturaCabecera> TieFacturaCabeceras { get; set; }

    public virtual DbSet<TieFacturaDetalle> TieFacturaDetalles { get; set; }

    public virtual DbSet<TieFacturaFormaPago> TieFacturaFormaPagos { get; set; }

    public virtual DbSet<TieFormaPago> TieFormaPagos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE8E9918C1");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.NombreCliente)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.NumDocumentoCliente)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("numDocumentoCliente");
        });

        modelBuilder.Entity<TieEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__TieEmpre__75D2CED46EFA7024");

            entity.ToTable("TieEmpresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.CorreoEmpresa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correoEmpresa");
            entity.Property(e => e.DireccionEmpresa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccionEmpresa");
            entity.Property(e => e.NombreEmpresa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreEmpresa");
            entity.Property(e => e.NumDocumento)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("numDocumento");
            entity.Property(e => e.TelefonoEmpresa)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefonoEmpresa");
        });

        modelBuilder.Entity<TieFacturaCabecera>(entity =>
        {
            entity.HasKey(e => e.IdFacturaCabecera).HasName("PK__TieFactu__377BAFEBE8962197");

            entity.ToTable("TieFacturaCabecera");

            entity.Property(e => e.IdFacturaCabecera).HasColumnName("idFacturaCabecera");
            entity.Property(e => e.EstadoFacturaCabecera)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("estadoFacturaCabecera");
            entity.Property(e => e.FechaFacturaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaFacturaCreacion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.NumDocumentoCliente)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("numDocumentoCliente");
            entity.Property(e => e.NumeroFactura)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numeroFactura");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.SubtotalFactura).HasColumnName("subtotalFactura");
            entity.Property(e => e.TotalFactura)
                .HasComputedColumnSql("([subtotalFactura]+[iva])", true)
                .HasColumnName("totalFactura");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TieFacturaCabeceras)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TieFacturaCabecera_idCliente");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.TieFacturaCabeceras)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TieFacturaCabecera_idEmpresa");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TieFacturaCabeceras)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TieFacturaCabecera_idUsuario");
        });

        modelBuilder.Entity<TieFacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.IdFacturaDetalle).HasName("PK__TieFactu__88DAD9E882D3E627");

            entity.ToTable("TieFacturaDetalle");

            entity.Property(e => e.IdFacturaDetalle).HasColumnName("idFacturaDetalle");
            entity.Property(e => e.CantidadProducto).HasColumnName("cantidadProducto");
            entity.Property(e => e.IdFacturaCabecera).HasColumnName("idFacturaCabecera");
            entity.Property(e => e.NombreProducto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreProducto");
            entity.Property(e => e.PrecioProducto).HasColumnName("precioProducto");
            entity.Property(e => e.SubtotalProducto)
                .HasComputedColumnSql("([precioProducto]*[cantidadProducto])", true)
                .HasColumnName("subtotalProducto");

            entity.HasOne(d => d.IdFacturaCabeceraNavigation).WithMany(p => p.TieFacturaDetalles)
                .HasForeignKey(d => d.IdFacturaCabecera)
                .HasConstraintName("FK_TieFacturaDetalle_idFacturaCabecera");
        });

        modelBuilder.Entity<TieFacturaFormaPago>(entity =>
        {
            entity.HasKey(e => e.IdFacturaFormaPago).HasName("PK__TieFactu__515274A1BFA8377E");

            entity.ToTable("TieFacturaFormaPago");

            entity.Property(e => e.IdFacturaFormaPago).HasColumnName("idFacturaFormaPago");
            entity.Property(e => e.IdFacturaCabecera).HasColumnName("idFacturaCabecera");
            entity.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");

            entity.HasOne(d => d.IdFacturaCabeceraNavigation).WithMany(p => p.TieFacturaFormaPagos)
                .HasForeignKey(d => d.IdFacturaCabecera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TieFacturaFormaPago_idFacturaCabecera");

            entity.HasOne(d => d.IdFormaPagoNavigation).WithMany(p => p.TieFacturaFormaPagos)
                .HasForeignKey(d => d.IdFormaPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TieFacturaFormaPago_idFormaPago");
        });

        modelBuilder.Entity<TieFormaPago>(entity =>
        {
            entity.HasKey(e => e.IdFormaPago).HasName("PK__TieForma__952893F6BCD954DC");

            entity.ToTable("TieFormaPago");

            entity.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6FB444230");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
