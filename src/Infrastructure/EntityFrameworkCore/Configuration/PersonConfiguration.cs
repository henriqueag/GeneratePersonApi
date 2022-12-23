using DocumentGeneratorApp.Domain;

namespace DocumentGeneratorApp.Infrastructure.EntityFrameworkCore;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Names");

        builder.HasKey(x => x.Id)
            .HasName("PK_Id_Name");

        builder.Property(x => x.Name)
            .HasMaxLength(80)
            .HasColumnType("varchar")
            .IsRequired();
                
        builder.Ignore(x => x.Cpf);
        
        builder.Ignore(x => x.Rg);
        
        builder.Ignore(x => x.BirthDate);
        
        builder.Ignore(x => x.Age);
        
        builder.Ignore(x => x.Phone);
        
        builder.Ignore(x => x.Email);

        builder.Ignore(x => x.Address);
    }
}
