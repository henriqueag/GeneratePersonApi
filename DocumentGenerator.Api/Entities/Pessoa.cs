using System;
using Newtonsoft.Json;

namespace DocumentGenerator.Api.Entities
{
    public class Pessoa
    {
        [JsonIgnore]
        public int Id { get; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNasc { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, string cpf, string rg, DateTime dataNasc, int idade, string telefone, string email, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            DataNasc = dataNasc;
            Idade = idade;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }
    }

    public class PessoaApi
    {

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNasc { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public EnderecoApi EnderecoApi { get; set; }
        
        public PessoaApi(string nome, string cpf, string rg, DateTime dataNasc, int idade, string telefone, string email, EnderecoApi enderecoApi)
        {
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            DataNasc = dataNasc;
            Idade = idade;
            Telefone = telefone;
            Email = email;
            EnderecoApi = enderecoApi;
        }
    }
}
