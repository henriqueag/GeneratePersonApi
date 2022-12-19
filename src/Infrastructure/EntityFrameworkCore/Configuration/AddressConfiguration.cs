using DocumentGeneratorApp.Domain;

namespace DocumentGeneratorApp.Infrastructure.EntityFrameworkCore;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id)
            .HasName("PK_AddressId_Address");

        builder.HasIndex(x => x.City)
            .HasDatabaseName("INDEX_City_Address");

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
