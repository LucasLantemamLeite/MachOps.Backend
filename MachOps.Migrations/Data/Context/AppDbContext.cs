using MachOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MachOps.Migrations.Data.Context;

public sealed class AppDbContext : DbContext
{
    public DbSet<MachineEntity> Machines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("server=localhost, 1433;database=MachOpsDb;User Id=sa;Password=Lucas1971!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}