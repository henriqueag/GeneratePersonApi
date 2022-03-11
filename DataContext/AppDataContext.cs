using DocumentGenerator.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocumentGenerator.DataContext
{
    public class AppDataContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        public AppDataContext()
        {
        }
        
        public AppDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
        }
    }
}