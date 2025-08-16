using MachOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MachOps.Migrations.Data.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Machinery> Machines { get; set; }
    public DbSet<UserAccount> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}