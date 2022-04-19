using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cobros.Service.Models
{
    public partial class CobrosDBContext : DbContext
    {
        public CobrosDBContext()
        {
        }

        public CobrosDBContext(DbContextOptions<CobrosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientMovement> ClientMovements { get; set; }
        public virtual DbSet<ClientPhone> ClientPhones { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-KDF797TT;Initial Catalog=CobrosDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DocumentNumber).IsUnicode(false);

                entity.Property(e => e.DocumentType).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ClientMovement>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.AmountType)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientMovements)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientMovements_Clients");
            });

            modelBuilder.Entity<ClientPhone>(entity =>
            {
                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Tag).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPhones)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientPhones_Clients");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SystemUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_SystemUsers_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
