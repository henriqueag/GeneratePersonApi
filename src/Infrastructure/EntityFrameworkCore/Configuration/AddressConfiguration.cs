using DocumentGeneratorApp.Domain;

namespace DocumentGeneratorApp.Infrastructure.EntityFrameworkCore;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id)
            .HasName("PK_Address_Id");

        builder.HasIndex(x => new { x.City, x.State })
            .HasDatabaseName("IX_Address_City_State");

        builder.Property(x => x.Cep)
            .HasMaxLength(10)
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.City)
            .HasMaxLength(80)
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.State)
            .HasMaxLength(2)
            .HasColumnType("char")
            .IsRequired();

        builder.Property(x => x.Ddd)
            .HasMaxLength(2)
            .HasColumnType("char")
            .IsRequired(required: false);

        builder.Property(x => x.IsCapital)
            .HasColumnType("bit");

        builder.Ignore(x => x.Complement);
        
        builder.Ignore(x => x.Street);

        builder.Ignore(x => x.District);
    }
}
