using MachOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MachOps.Migrations.Data.Mapping;

public sealed class MachineMap : IEntityTypeConfiguration<Machinery>
{
    public void Configure(EntityTypeBuilder<Machinery> builder)
    {
        builder.ToTable("Machines");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("Int")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(x => x.Value)
                .HasColumnName("Name")
                .HasColumnType("Nvarchar(30)")
                .IsRequired();

            name.HasIndex(x => x.Value, "Unique_Key_Name_Machines")
                .IsUnique();
        });

        builder.OwnsOne(x => x.MachType, machType =>
        {
            machType.Property(x => x.Value)
                .HasColumnName("Type")
                .HasColumnType("Int")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Status, status =>
        {
            status.Property(x => x.Value)
                .HasColumnName("Status")
                .HasColumnType("Int")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Location, location =>
        {
            location.Property(x => x.Value)
                .HasColumnName("Location")
                .HasColumnType("Nvarchar(20)");
        });

        builder.OwnsOne(x => x.CreatedAt, create =>
        {
            create.Property(x => x.Value)
                .HasColumnName("CreateAt")
                .HasColumnType("Datetime")
                .IsRequired();
        });

        builder.OwnsOne(x => x.LastUpdatedAt, update =>
        {
            update.Property(x => x.Value)
                .HasColumnName("UpdateAt")
                .HasColumnType("DateTime2")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Description, description =>
        {
            description.Property(x => x.Value)
                .HasColumnName("Description")
                .HasColumnType("Nvarchar(100)");
        });

        builder.OwnsOne(x => x.MaintenanceStart, start =>
        {
            start.Property(x => x.Value)
                .HasColumnName("Start")
                .HasColumnType("Date");
        });

        builder.OwnsOne(x => x.MaintenanceReturn, expected =>
        {
            expected.Property(x => x.Value)
                .HasColumnName("Return")
                .HasColumnType("Date");
        });
    }
}
