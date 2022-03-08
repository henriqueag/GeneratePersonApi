using GeneratePersonApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneratePersonApi.DataContext
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("nomes");
            builder.Property(x => x.Id).HasColumnName("id_nome").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(80)").IsRequired();
            builder.Ignore(x => x.Cpf);
            builder.Ignore(x => x.Rg);
            builder.Ignore(x => x.DataNasc);
            builder.Ignore(x => x.Idade);
            builder.Ignore(x => x.Telefone);
            builder.Ignore(x => x.Email);
            builder.Ignore(x => x.Endereco);
        }
    }
}