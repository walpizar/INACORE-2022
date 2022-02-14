using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities;

#nullable disable

namespace Data
{
    public partial class dbPOOContext : DbContext
    {
        public dbPOOContext()
        {
        }

        public dbPOOContext(DbContextOptions<dbPOOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCategoria> TbCategorias { get; set; }
        public virtual DbSet<TbEstudiante> TbEstudiantes { get; set; }
        public virtual DbSet<TbImpuesto> TbImpuestos { get; set; }
        public virtual DbSet<TbPersona> TbPersonas { get; set; }
        public virtual DbSet<TbProducto> TbProductos { get; set; }
        public virtual DbSet<TbProveedore> TbProveedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=dbPOO;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TbCategoria>(entity =>
            {
                entity.ToTable("tbCategorias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TbEstudiante>(entity =>
            {
                entity.ToTable("tbEstudiantes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carnet)
                    .HasMaxLength(10)
                    .HasColumnName("carnet")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.Horario)
                    .HasMaxLength(500)
                    .HasColumnName("horario")
                    .IsFixedLength(true);

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.TbEstudiantes)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_tbEstudiantes_tbPersona");
            });

            modelBuilder.Entity<TbImpuesto>(entity =>
            {
                entity.ToTable("tbImpuestos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<TbPersona>(entity =>
            {
                entity.ToTable("tbPersona");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(30)
                    .HasColumnName("apellido1")
                    .IsFixedLength(true);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .HasColumnName("apellido2")
                    .IsFixedLength(true);

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("identificacion")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.TipoId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("tipoId")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TbProducto>(entity =>
            {
                entity.ToTable("tbProductos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("codigo")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdImpuesto).HasColumnName("idImpuesto");

                entity.Property(e => e.IdProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("idProveedor")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.PrecioCosto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("precioCosto");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("precioVenta");

                entity.Property(e => e.Utilidad)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("utilidad");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.TbProductos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProductos_tbCategorias");

                entity.HasOne(d => d.IdImpuestoNavigation)
                    .WithMany(p => p.TbProductos)
                    .HasForeignKey(d => d.IdImpuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProductos_tbImpuestos");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.TbProductos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProductos_tbProveedores");
            });

            modelBuilder.Entity<TbProveedore>(entity =>
            {
                entity.ToTable("tbProveedores");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellido1")
                    .IsFixedLength(true);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellido2")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
