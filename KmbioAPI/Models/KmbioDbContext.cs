using System;
using System.Collections.Generic;
using KmbioAPI.Authentication;
using Microsoft.EntityFrameworkCore;

namespace KmbioAPI.Models;

public partial class KmbioDbContext : DbContext
{
    public KmbioDbContext()
    {
    }

    public KmbioDbContext(DbContextOptions<KmbioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Auditoria> Auditorias { get; set; }

    public virtual DbSet<Capitale> Capitales { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Convertibilidade> Convertibilidades { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<GastosRecurrente> GastosRecurrentes { get; set; }

    public virtual DbSet<Merchant> Merchants { get; set; }

    public virtual DbSet<MetodosDePago> MetodosDePagos { get; set; }

    public virtual DbSet<Recomendacione> Recomendaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=KmbioDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Auditoria>(entity =>
        {
            entity.HasIndex(e => e.UsuarioId, "IX_Auditorias_UsuarioId");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Auditoria).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Capitale>(entity =>
        {
            entity.HasIndex(e => e.UsuarioId, "IX_Capitales_UsuarioId");

            entity.Property(e => e.CapitalTotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Capitales).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasIndex(e => e.UsuarioId, "IX_Categorias_UsuarioId");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Categoria).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Convertibilidade>(entity =>
        {
            entity.Property(e => e.Tasa).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasIndex(e => e.CategoriaId, "IX_Gastos_CategoriaId");

            entity.HasIndex(e => e.MetodoDePagoId, "IX_Gastos_MetodoDePagoId");

            entity.HasIndex(e => e.UserId, "IX_Gastos_UserId");

            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.MetodoDePago).WithMany(p => p.Gastos).HasForeignKey(d => d.MetodoDePagoId);

            entity.HasOne(d => d.User).WithMany(p => p.Gastos).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<GastosRecurrente>(entity =>
        {
            entity.HasIndex(e => e.CategoriaId, "IX_GastosRecurrentes_CategoriaId");

            entity.HasIndex(e => e.MetodoDePagoId, "IX_GastosRecurrentes_MetodoDePagoId");

            entity.HasIndex(e => e.UsuarioId, "IX_GastosRecurrentes_UsuarioId");

            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.GastosRecurrentes).HasForeignKey(d => d.CategoriaId);

            entity.HasOne(d => d.MetodoDePago).WithMany(p => p.GastosRecurrentes).HasForeignKey(d => d.MetodoDePagoId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.GastosRecurrentes).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<MetodosDePago>(entity =>
        {
            entity.ToTable("MetodosDePago");

            entity.HasIndex(e => e.UsuarioId, "IX_MetodosDePago_UsuarioId");

            entity.HasOne(d => d.Usuario).WithMany(p => p.MetodosDePagos).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Recomendacione>(entity =>
        {
            entity.HasIndex(e => e.PresupuestoId, "IX_Recomendaciones_PresupuestoId");

            entity.HasIndex(e => e.UsuarioId, "IX_Recomendaciones_UsuarioId");

            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Presupuesto).WithMany(p => p.Recomendaciones).HasForeignKey(d => d.PresupuestoId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Recomendaciones).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Usuarios_Email").IsUnique();

            entity.HasIndex(e => e.Username, "IX_Usuarios_Username").IsUnique();
        });
        */
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
