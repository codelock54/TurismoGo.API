using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TurismoGo.Domain.CORE.Entity;

namespace TurismoGo.Domain.Infrastructure.Data;

public partial class TurismoDbContext : DbContext
{
    public TurismoDbContext()
    {
    }

    public TurismoDbContext(DbContextOptions<TurismoDbContext> options)
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
        => optionsBuilder.UseSqlServer("Server=LAPTOP-KSCIP1PS;Database=turismo_db;TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK__Activida__C5FAF47E2B80935C");

            entity.Property(e => e.IdActividad).HasColumnName("ID_Actividad");
            entity.Property(e => e.Destino).HasMaxLength(100);
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.NombreActividad).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Actividad)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__ID_Em__3E52440B");
        });

        modelBuilder.Entity<EmpresaTurismo>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__EmpresaT__F4BB60399A65A920");

            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.NombreEmpresa).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reserva__12CAD9F43E2F0755");

            entity.Property(e => e.IdReserva).HasColumnName("ID_Reserva");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.IdActividad).HasColumnName("ID_Actividad");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__ID_Acti__4222D4EF");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__ID_Usua__412EB0B6");
        });

        modelBuilder.Entity<Reseña>(entity =>
        {
            entity.HasKey(e => e.IdReseña).HasName("PK__Reseña__B4FBAB756D71D247");

            entity.Property(e => e.IdReseña).HasColumnName("ID_Reseña");
            entity.Property(e => e.IdActividad).HasColumnName("ID_Actividad");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.Reseña)
                .HasForeignKey(d => d.IdActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseña__ID_Activ__45F365D3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reseña)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseña__ID_Usuar__44FF419A");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__202AD2206AAC7214");

            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DE4431C50366CF82");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__ID_Rol__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
