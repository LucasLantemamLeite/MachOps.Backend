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

        builder.OwnsOne(x => x.MachineryName, name =>
        {
            name.Property(x => x.Value)
                .HasColumnName("Name")
                .HasColumnType("Nvarchar(30)")
                .IsRequired();

            name.HasIndex(x => x.Value, "Unique_Key_Name_Machines")
                .IsUnique();
        });

        builder.OwnsOne(x => x.MachineryType, machType =>
        {
            machType.Property(x => x.Value)
                .HasColumnName("Type")
                .HasColumnType("Int")
                .IsRequired();
        });

        builder.OwnsOne(x => x.MachineryStatus, status =>
        {
            status.Property(x => x.Value)
                .HasColumnName("Status")
                .HasColumnType("Int")
                .IsRequired();
        });

        builder.OwnsOne(x => x.MachineryLocation, location =>
        {
            location.Property(x => x.Value)
                .HasColumnName("Location")
                .HasColumnType("Nvarchar(20)");
        });

        builder.OwnsOne(x => x.MachineryCreatedAt, create =>
        {
            create.Property(x => x.Value)
                .HasColumnName("CreateAt")
                .HasColumnType("Datetime")
                .IsRequired();
        });

        builder.OwnsOne(x => x.MachineryLastUpdatedAt, update =>
        {
            update.Property(x => x.Value)
                .HasColumnName("UpdateAt")
                .HasColumnType("DateTime2")
                .IsRequired();
        });

        builder.OwnsOne(x => x.MachineryDescription, description =>
        {
            description.Property(x => x.Value)
                .HasColumnName("Description")
                .HasColumnType("Nvarchar(100)");
        });

        builder.OwnsOne(x => x.MaintenanceStartDate, start =>
        {
            start.Property(x => x.Value)
                .HasColumnName("Start")
                .HasColumnType("Date");
        });

        builder.OwnsOne(x => x.ExpectedReturnDate, expected =>
        {
            expected.Property(x => x.Value)
                .HasColumnName("Return")
                .HasColumnType("Date");
        });
    }
}
