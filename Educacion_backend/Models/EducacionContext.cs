using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Educacion_backend.Models
{
    public partial class EducacionContext : DbContext
    {
        public EducacionContext()
        {
        }

        public EducacionContext(DbContextOptions<EducacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacione> Calificaciones { get; set; } = null!;
        public virtual DbSet<Colegio> Colegios { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost;database=Educacion; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.ToTable("CALIFICACIONES");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Calificacion)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("calificacion");

                entity.Property(e => e.IdColegio)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("idColegio");

                entity.Property(e => e.IdMateria)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("idMateria");

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.IdColegioNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdColegio)
                    .HasConstraintName("fk_Colegio_Calificaciones");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("fk_Materia");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_Usuario");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.ToTable("COLEGIO");

                entity.HasIndex(e => e.Nombre, "UQ__COLEGIO__72AFBCC6DDDDEE22")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.TipoColegio)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("tipoColegio");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.ToTable("MATERIA");

                entity.HasIndex(e => e.Nombre, "UQ__MATERIA__72AFBCC652C6A458")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.Curso)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("curso");

                entity.Property(e => e.DocenteAsignado)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("docenteAsignado");

                entity.Property(e => e.IdColegio)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("idColegio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroEstudiantes).HasColumnName("numeroEstudiantes");

                entity.Property(e => e.Paralelo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("paralelo");

                entity.HasOne(d => d.IdColegioNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdColegio)
                    .HasConstraintName("fk_Colegio");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Username, "UQ__USUARIO__F3DBC5720C1B8306")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Rol)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.Property(e => e.Username)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
