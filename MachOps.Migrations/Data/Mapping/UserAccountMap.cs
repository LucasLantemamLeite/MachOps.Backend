using MachOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MachOps.Migrations.Data.Mapping;

public sealed class UserAccountMap : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("Users");

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
                .HasColumnType("Nvarchar(100)")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(x => x.Value)
                .HasColumnName("Email")
                .HasColumnType("Nvarchar(254)")
                .IsRequired();

            email.HasIndex(x => x.Value, "Unique_Key_Email_Users")
                .IsUnique();
        });

        builder.OwnsOne(x => x.Password, password =>
        {
            password.Property(x => x.Value)
                .HasColumnName("Password")
                .HasColumnType("Nvarchar(100)")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Phone, phone =>
        {
            phone.Property(x => x.Value)
                .HasColumnName("Phone")
                .HasColumnType("Nvarchar(20)")
                .IsRequired();

            phone.HasIndex(x => x.Value, "Unique_Key_Phone_Users")
                .IsUnique();
        });

        builder.OwnsOne(x => x.CreatedAt, create =>
        {
            create.Property(x => x.Value)
                .HasColumnName("CreatedAt")
                .HasColumnType("SmallDateTime")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Active, active =>
        {
            active.Property(x => x.Value)
                .HasColumnName("Active")
                .HasColumnType("Bit")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Role, role =>
        {
            role.Property(x => x.Value)
                .HasColumnName("Role")
                .HasColumnType("Int")
                .IsRequired();
        });
    }
}
