using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI;

public partial class veterinariaContext : DbContext
{
    public veterinariaContext()
    {
    }

    public veterinariaContext(DbContextOptions<veterinariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GesCliente> GesClientes { get; set; }
    public virtual DbSet<GesPaciente> GesPacientes { get; set; }
    public virtual DbSet<GesTipoPaciente> GesTipoPacientes { get; set; }

    public virtual DbSet<TieEmpresa> TieEmpresas { get; set; }

    public virtual DbSet<TieFacturaCabecera> TieFacturaCabeceras { get; set; }

    public virtual DbSet<TieFacturaDetalle> TieFacturaDetalles { get; set; }

    public virtual DbSet<TieFacturaFormaPago> TieFacturaFormaPagos { get; set; }

    public virtual DbSet<TieFormaPago> TieFormaPagos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GesCliente>(entity =>
        {
            entity.HasKey(e => e.idCliente).HasName("PK__GesClien__885457EEBA7D11CA");

            entity.ToTable("GesCliente");

            entity.ToTable(tb => tb.HasTrigger("ActualizarFechaActualizacion"));
            entity.ToTable(tb => tb.HasTrigger("EliminacionLogica"));
            entity.ToTable(tb => tb.HasTrigger("InsertarEstado"));
            entity.ToTable(tb => tb.HasTrigger("InsertarFechaCreacion"));

            entity.Property(e => e.idCliente).HasColumnName("idCliente");

            entity.Property(e => e.numDocumento)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("numDocumento");

            entity.Property(e => e.nombreCliente)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreCliente");

            entity.Property(e => e.apellidoCliente)
            .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoCliente");

            entity.Property(e => e.fechaNac)
            .HasColumnType("datetime")
                .HasColumnName("fechaNac");

            entity.Property(e => e.telefono)
            .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.Property(e => e.direccion)
            .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");

            entity.Property(e => e.correo)
            .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");

            entity.Property(e => e.estadoCliente)
            .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estadoCliente");

            entity.Property(e => e.fechaCreacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");

            entity.Property(e => e.fechaActualizacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");

            entity.Property(e => e.fechaEliminacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");


        });

        modelBuilder.Entity<GesPaciente>(entity =>
        {
            entity.HasKey(e => e.idPaciente).HasName("PK__GesPacie__F48A08F2847BD77D");
            entity.ToTable("GesPaciente");

            entity.ToTable(tb => tb.HasTrigger("ActualizarFechaActualizacionPaciente"));
            entity.ToTable(tb => tb.HasTrigger("EliminacionLogicaPaciente"));
            entity.ToTable(tb => tb.HasTrigger("InsertarEstadoPaciente"));
            entity.ToTable(tb => tb.HasTrigger("InsertarFechaCreacionPaciente"));


            entity.Property(e => e.idPaciente).HasColumnName("idPaciente");

            entity.Property(e => e.nombrePaciente)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombrePaciente");

            entity.Property(e => e.fechaNac)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("fechaNac");

            entity.Property(e => e.raza)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("raza");

            entity.Property(e => e.idTipoPaciente)
                .IsRequired()
                .HasColumnName("idTipoPaciente");

            entity.Property(e => e.idCliente)
            .IsRequired()
                .HasColumnName("idCliente");

            entity.Property(e => e.estadoPaciente)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estadoPaciente");

            entity.Property(e => e.fechaCreacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");

            entity.Property(e => e.fechaActualizacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");

            entity.Property(e => e.fechaEliminacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");

            entity.Property(e => e.edad)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("edad");

            entity.HasOne(d => d.TipoPaciente)
                .WithMany(p => p.GesPacientes)
                .HasForeignKey(d => d.idTipoPaciente)
                .HasConstraintName("FK__GesPacien__idTip__656C112C");

            entity.HasOne(d => d.Cliente)
                  .WithMany(c => c.GesPacientes)
                  .HasForeignKey(p => p.idCliente)
                  .HasConstraintName("FK__GesPacien__idCli__6477ECF3");
        });

        modelBuilder.Entity<GesTipoPaciente>(entity =>
        {
            entity.HasKey(e => e.idTipoPaciente).HasName("PK__GesTipoP__C42BE6E13E65EF30");

            entity.ToTable("GesTipoPaciente");


            entity.ToTable(tb => tb.HasTrigger("ActualizarFechaActualizacionTipoPaciente"));
            entity.ToTable(tb => tb.HasTrigger("EliminacionLogicaTipoPaciente"));
            entity.ToTable(tb => tb.HasTrigger("InsertarEstadoTipoPaciente"));
            entity.ToTable(tb => tb.HasTrigger("InsertarFechaCreacionTipoPaciente"));

            entity.Property(e => e.idTipoPaciente).HasColumnName("idTipoPaciente");

            entity.Property(e => e.tipoPaciente)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoPaciente");

            entity.Property(e => e.estadoTipoPaciente)
            .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estadoTipoPaciente");

            entity.Property(e => e.fechaCreacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");

            entity.Property(e => e.fechaActualizacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");

            entity.Property(e => e.fechaEliminacion)
            .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
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
            entity.HasKey(e => e.IdFacturaCabecera).HasName("PK__TieFactu__377BAFEB2BB6A335");

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
            entity.Property(e => e.TotalFactura).HasColumnName("totalFactura");

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
            entity.HasKey(e => e.IdFacturaDetalle).HasName("PK__TieFactu__88DAD9E895334761");

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
            entity.Property(e => e.SubtotalProducto).HasColumnName("subtotalProducto");

            entity.HasOne(d => d.IdFacturaCabeceraNavigation).WithMany(p => p.TieFacturaDetalles)
                .HasForeignKey(d => d.IdFacturaCabecera)
                .HasConstraintName("FK_TieFacturaDetalle_idFacturaCabecera");
        });

        modelBuilder.Entity<TieFacturaFormaPago>(entity =>
        {
            entity.HasKey(e => e.IdFacturaFormaPago).HasName("PK__TieFactu__515274A107064F24");

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
