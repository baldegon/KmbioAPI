using System;
using System.Collections.Generic;
using KmbioAPI.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KmbioAPI.Models;

public partial class KmbioDbContext : IdentityDbContext<Usuario, IdentityRole, string>
{

    public KmbioDbContext(DbContextOptions<KmbioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditoria> Auditorias { get; set; }

    public virtual DbSet<Capitale> Capitales { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Convertibilidade> Convertibilidades { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<GastosRecurrente> GastosRecurrentes { get; set; }

    public virtual DbSet<Merchant> Merchants { get; set; }

    public virtual DbSet<MetodosDePago> MetodosDePagos { get; set; }

    public virtual DbSet<Recomendacione> Recomendaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=KmbioDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        string adminRoleId = Guid.NewGuid().ToString();
        string clientRoleId = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole
            {
                Id = clientRoleId,
                Name = "Client",
                NormalizedName = "CLIENT",
                ConcurrencyStamp = clientRoleId
            }
        );




        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
