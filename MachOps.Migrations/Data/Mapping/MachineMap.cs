using MachOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MachOps.Migrations.Data.Mapping;

public sealed class MachineMap : IEntityTypeConfiguration<MachineEntity>
{
    public void Configure(EntityTypeBuilder<MachineEntity> builder)
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
                .HasColumnName("MachType")
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

        builder.OwnsOne(x => x.CreateAt, create =>
        {
            create.Property(x => x.Value)
                .HasColumnName("CreateAt")
                .HasColumnType("Datetime")
                .IsRequired();
        });

        builder.OwnsOne(x => x.UpdateAt, update =>
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

        builder.OwnsOne(x => x.MaintenanceStartDate, start =>
        {
            start.Property(x => x.Value)
                .HasColumnName("MaintenanceStartDate")
                .HasColumnType("Date");
        });

        builder.OwnsOne(x => x.ExpectedReturnDate, expected =>
        {
            expected.Property(x => x.Value)
                .HasColumnName("ExpectedReturnDate")
                .HasColumnType("Date");
        });
    }
}
