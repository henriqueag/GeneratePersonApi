using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeneratePersonApi.DataContext;
using GeneratePersonApi.Entities;
using GeneratePersonApi.Entities.Enum;
using GeneratePersonApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeneratePersonApi.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly AppDataContext _context;
        private readonly IEnderecoService _service;

        public PessoaService(AppDataContext context, IEnderecoService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<Pessoa> GerarPessoaAsync(int? idade = null, EstadosBR? estado = null, string cidade = null, bool gerarComPonto = true)
        {
            Pessoa pessoa = null;
            // Idade definida. Estado e cidade aleatória
            if (idade != null && estado == null && cidade == null)
            {
                Endereco endereco = await _service.GetEnderecoAsync(estado, cidade);
                string nome = GerarNomeAleatorio().Result;
                string cpf = GeradorDeDados.GeraCpfValidado(gerarComPonto);
                string rg = GeradorDeDados.GeraRgValido(gerarComPonto);
                DateTime dataNasc = GeradorDeDados.GerarDataPorIdade(idade.Value);
                string telefone = GeradorDeDados.GeraTelefoneAleatorio(endereco);
                string email = GeradorDeDados.GeraEmailAleatorio(nome);
                pessoa = new Pessoa(nome, cpf, rg, dataNasc, idade.Value, telefone, email, endereco);
            }
            else
            // Idade e estado definida. Cidade aleatória
            if (idade != null && estado != null && cidade == null)
            {
                Endereco endereco = await _service.GetEnderecoAsync(estado, cidade);
                string nome = GerarNomeAleatorio().Result;
                string cpf = GeradorDeDados.GeraCpfValidado(gerarComPonto);
                string rg = GeradorDeDados.GeraRgValido(gerarComPonto);
                DateTime dataNasc = GeradorDeDados.GerarDataPorIdade(idade.Value);
                string telefone = GeradorDeDados.GeraTelefoneAleatorio(endereco);
                string email = GeradorDeDados.GeraEmailAleatorio(nome);
                pessoa = new Pessoa(nome, cpf, rg, dataNasc, idade.Value, telefone, email, endereco);
            }
            else
            // Todos os parâmetros definidos
            if (idade != null && estado != null && cidade != null)
            {
                Endereco endereco = await _service.GetEnderecoAsync(estado, cidade);
                string nome = GerarNomeAleatorio().Result;
                string cpf = GeradorDeDados.GeraCpfValidado(gerarComPonto);
                string rg = GeradorDeDados.GeraRgValido(gerarComPonto);
                DateTime dataNasc = GeradorDeDados.GerarDataPorIdade(idade.Value);
                string telefone = GeradorDeDados.GeraTelefoneAleatorio(endereco);
                string email = GeradorDeDados.GeraEmailAleatorio(nome);
                pessoa = new Pessoa(nome, cpf, rg, dataNasc, idade.Value, telefone, email, endereco);
            }
            else
            // Idade e cidade aleatória. Estado definido
            if (idade == null && estado != null && cidade == null)
            {
                Endereco endereco = await _service.GetEnderecoAsync(estado, cidade);
                string nome = GerarNomeAleatorio().Result;
                string cpf = GeradorDeDados.GeraCpfValidado(gerarComPonto);
                string rg = GeradorDeDados.GeraRgValido(gerarComPonto);
                DateTime dataNasc = GeradorDeDados.GerarIdadeAleatoria();
                idade = GeradorDeDados.CalculaIdade(dataNasc);
                string telefone = GeradorDeDados.GeraTelefoneAleatorio(endereco);
                string email = GeradorDeDados.GeraEmailAleatorio(nome);
                pessoa = new Pessoa(nome, cpf, rg, dataNasc, idade.Value, telefone, email, endereco);
            }
            else
            // Idade aleatória. Estado e cidade definida
            if (idade == null && estado != null && cidade != null)
            {
                Endereco endereco = await _service.GetEnderecoAsync(estado, cidade);
                string nome = GerarNomeAleatorio().Result;
                string cpf = GeradorDeDados.GeraCpfValidado(gerarComPonto);
                string rg = GeradorDeDados.GeraRgValido(gerarComPonto);
                DateTime dataNasc = GeradorDeDados.GerarIdadeAleatoria();
                idade = GeradorDeDados.CalculaIdade(dataNasc);
                string telefone = GeradorDeDados.GeraTelefoneAleatorio(endereco);
                string email = GeradorDeDados.GeraEmailAleatorio(nome);
                pessoa = new Pessoa(nome, cpf, rg, dataNasc, idade.Value, telefone, email, endereco);
            }
            else
            // Todos os parametros aleatórios
            if (idade == null && estado == null && cidade == null)
            {
                Endereco endereco = await _service.GetEnderecoAsync(estado, cidade);
                string nome = GerarNomeAleatorio().Result;
                string cpf = GeradorDeDados.GeraCpfValidado(gerarComPonto);
                string rg = GeradorDeDados.GeraRgValido(gerarComPonto);
                DateTime dataNasc = GeradorDeDados.GerarIdadeAleatoria();
                idade = GeradorDeDados.CalculaIdade(dataNasc);
                string telefone = GeradorDeDados.GeraTelefoneAleatorio(endereco);
                string email = GeradorDeDados.GeraEmailAleatorio(nome);
                pessoa = new Pessoa(nome, cpf, rg, dataNasc, idade.Value, telefone, email, endereco);
            }
            return pessoa;
        }

        public async Task<IEnumerable<Pessoa>> GerarListPessoaAsync(int quantidade = 1, int? idade = null, EstadosBR? estado = null, string cidade = null, bool gerarComPonto = true)
        {
            List<Pessoa> pessoas = new();
            int cont = 0;

            while (true)
            {
                cont++;
                var pessoa = await GerarPessoaAsync(idade, estado, cidade, gerarComPonto);
                pessoas.Add(pessoa);
                if (cont == quantidade)
                {
                    break;
                }
            }
            return pessoas;
        }

        private async Task<string> GerarNomeAleatorio()
        {
            var nomes = await _context.Pessoas.ToListAsync();
            var random = new Random();
            var nome = nomes[random.Next(0, nomes.Count)].Nome;
            return nome;
        }
    }
}