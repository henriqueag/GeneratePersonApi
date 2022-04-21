using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentGenerator.Lib.DataContext;
using DocumentGenerator.Lib.Entities;
using DocumentGenerator.Lib.Entities.Enum;
using DocumentGenerator.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentGenerator.Lib.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDataContext _context;
        private readonly IEnderecoService _service;

        public PersonService(AppDataContext context, IEnderecoService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<Pessoa> GerarPessoaAsync(int? idade = null, EstadosBR? estado = null, string cidade = null, bool gerarComPonto = true)
        {
            Pessoa pessoa = null;

            async Task<Pessoa> GetPessoa()
            {
                Endereco endereco = await _service.GetEnderecoAsync(estado, cidade);
                var uf = (EstadosBR)Enum.Parse(typeof(EstadosBR), endereco.Uf);
                string nome = GerarNomeAleatorio().Result;
                string cpf = DocGeneratorService.GeraCPFValido(uf, gerarComPonto);
                string rg = DocGeneratorService.GeraRGValido(gerarComPonto);
                string telefone = DocGeneratorService.GeraTelefoneAleatorio(endereco);
                string email = DocGeneratorService.GeraEmailAleatorio(nome);
                // idade
                DateTime dataNasc;
                if (idade == null)
                {
                    dataNasc = DocGeneratorService.GerarIdadeAleatoria();
                    idade = DocGeneratorService.CalculaIdade(dataNasc);
                }
                else
                {
                    dataNasc = DocGeneratorService.GerarDataPorIdade(idade.Value);
                }
                // retorno
                return new Pessoa(nome, cpf, rg, dataNasc, idade.Value, telefone, email, endereco);
            }

            // Idade definida. Estado e cidade aleatória
            if (idade != null && estado == null && cidade == null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Idade e estado definida. Cidade aleatória
            if (idade != null && estado != null && cidade == null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Todos os parâmetros definidos
            if (idade != null && estado != null && cidade != null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Idade e cidade aleatória. Estado definido
            if (idade == null && estado != null && cidade == null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Idade aleatória. Estado e cidade definida
            if (idade == null && estado != null && cidade != null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Todos os parametros aleatórios
            if (idade == null && estado == null && cidade == null)
            {
                pessoa = await GetPessoa();
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