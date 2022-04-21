using DocumentGenerator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentGenerator.Lib.DataContext
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco");
            builder.Property(end => end.Id).HasColumnName("id_endereco").IsRequired();
            builder.Property(end => end.Cep).HasColumnName("cep").HasColumnType("varchar(10)").IsRequired();
            builder.Property(end => end.Cidade).HasColumnName("cidade").HasColumnType("varchar(80)").IsRequired();
            builder.Property(end => end.Uf).HasColumnName("estado").HasColumnType("char(2)").IsRequired();
            builder.Property(end => end.DDD).HasColumnName("ddd").HasColumnType("char(2)").IsRequired();
            builder.Ignore(end => end.Bairro);
            builder.Ignore(end => end.Complemento);
            builder.Ignore(end => end.Logradouro);
        }
    }
}