using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TurismoGo.Domain.Core.Entity;

namespace TurismoGo.Domain.Infrastructure.Data;

public partial class TurismoGoContext : DbContext
{
    public TurismoGoContext()
    {
    }

    public TurismoGoContext(DbContextOptions<TurismoGoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividad { get; set; }

    public virtual DbSet<EmpresaTurismo> EmpresaTurismo { get; set; }

    public virtual DbSet<Reserva> Reserva { get; set; }

    public virtual DbSet<Reseña> Reseña { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-KSCIP1PS;Database=TurismoGo;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK__Activida__C5FAF47E77F92182");

            entity.Property(e => e.IdActividad).HasColumnName("ID_Actividad");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Destino)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaInicio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.NombreActividad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Actividad)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__ID_Em__4316F928");
        });

        modelBuilder.Entity<EmpresaTurismo>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__EmpresaT__F4BB60396955C00D");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__EmpresaT__531402F380864B28").IsUnique();

            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reserva__12CAD9F4C3787E66");

            entity.Property(e => e.IdReserva).HasColumnName("ID_Reserva");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdActividad).HasColumnName("ID_Actividad");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__ID_Acti__47DBAE45");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__ID_Usua__46E78A0C");
        });

        modelBuilder.Entity<Reseña>(entity =>
        {
            entity.HasKey(e => e.IdReseña).HasName("PK__Reseña__B4FBAB75FD51E22E");

            entity.Property(e => e.IdReseña).HasColumnName("ID_Reseña");
            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaReseña)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdActividad).HasColumnName("ID_Actividad");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.Reseña)
                .HasForeignKey(d => d.IdActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseña__ID_Activ__4CA06362");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reseña)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseña__ID_Usuar__4BAC3F29");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__202AD22098385AA8");

            entity.HasIndex(e => e.NombreRol, "UQ__Rol__4F0B537F002F2BBD").IsUnique();

            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DE4431C5A6EDFF0A");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuario__531402F3A3E6BF6E").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__ID_Rol__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
