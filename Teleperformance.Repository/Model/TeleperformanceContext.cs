using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Teleperformance.Model
{
    public partial class TeleperformanceContext : DbContext
    {
        public TeleperformanceContext()
        {
        }

        public TeleperformanceContext(DbContextOptions<TeleperformanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }
        public virtual DbSet<Kind> Kinds { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vium> Via { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Teleperformance;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](36),newid(),(0)))");

                entity.Property(e => e.Letra1)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Letra2)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MunicipioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Nro1)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Nro2)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.NroyComplementos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ViaId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contact__Municip__0E6E26BF");

                entity.HasOne(d => d.Via)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ViaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contact__ViaId__0D7A0286");
            });

            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.ToTable("IdentificationType");

                entity.HasIndex(e => e.Name, "UQ__Identifi__737584F6309A6A93")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](36),newid(),(0)))");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kind>(entity =>
            {
                entity.ToTable("Kind");

                entity.HasIndex(e => e.Name, "UQ__Kind__737584F60EE19AD9")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](36),newid(),(0)))");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("Municipio");

                entity.HasIndex(e => e.Name, "UQ__Municipi__737584F6878DAC7C")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](36),newid(),(0)))");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.IdentificationNumber, "UQ__User__9CD1469414AA3AFD")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](36),newid(),(0)))");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificationNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificationTypeId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Kind)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK__User__ContactId__339FAB6E");

                entity.HasOne(d => d.IdentificationType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdentificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__Identifica__32AB8735");

                entity.HasOne(d => d.KindNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Kind)
                    .HasConstraintName("FK__User__Kind__31B762FC");
            });

            modelBuilder.Entity<Vium>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Via__737584F62AF1393D")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](36),newid(),(0)))");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
