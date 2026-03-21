using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web.Domain.Models;
namespace Web.Infrastructure.Context;

public partial class SystemAdminApiContext : DbContext
{
 

    public SystemAdminApiContext(DbContextOptions<SystemAdminApiContext> options) : base(options)
    {
    }

    public DbSet<AdminModel> Admins { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC07AD3A9BD7");

            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);
        });
    }

}
