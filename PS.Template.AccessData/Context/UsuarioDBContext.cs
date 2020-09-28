using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PS.Template.AccessData.cualquiera
{
    public partial class UsuarioDBContext : DbContext
    {
        public UsuarioDBContext()
        {
        }

        public UsuarioDBContext(DbContextOptions<UsuarioDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= DESKTOP-E96Q542; Initial Catalog= UsuarioDB; user=sa; password=rosario1803; Integrated Security= true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6EF59050A");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNac)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
