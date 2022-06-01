using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentGenerator.Api.DataContext;
using DocumentGenerator.Api.Entities;
using DocumentGenerator.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentGenerator.Api.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDataContext _context;
        private readonly IEnderecoService _enderecoService;
        private readonly IDocumentService _documentService;

        public PersonService(AppDataContext context, IEnderecoService service, IDocumentService documentService)
        {
            _context = context;
            _enderecoService = service;
            _documentService = documentService;
        }

        public async Task<Pessoa> GerarPessoaAsync(int? idade = null, string estadoBR_sigla = null, string cidade = null, bool gerarComMascara = true)
        {
            Pessoa pessoa = null;

            async Task<Pessoa> GetPessoa()
            {
                var endereco = await _enderecoService.GetEnderecoAsync(estadoBR_sigla, cidade);
                var uf = endereco.Uf;
                var nome = GerarNomeAleatorio().Result;
                var cpf = _documentService.GeraCPFValido(uf, gerarComMascara);
                var rg = _documentService.GeraRGValido(gerarComMascara);
                var telefone = _documentService.GeraTelefoneAleatorio(endereco);
                var email = _documentService.GeraEmailAleatorio(nome);
                // idade
                DateTime dataNasc;
                if (idade == null)
                {
                    dataNasc = _documentService.GerarIdadeAleatoria();
                    idade = _documentService.CalculaIdade(dataNasc);
                }
                else
                {
                    dataNasc = _documentService.GerarDataPorIdade(idade.Value);
                }
                // retorno
                return new Pessoa(nome, cpf, rg, dataNasc, idade.Value, telefone, email, endereco);
            }

            // Idade definida. Estado e cidade aleatória
            if (idade != null && estadoBR_sigla == null && cidade == null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Idade e estado definida. Cidade aleatória
            if (idade != null && estadoBR_sigla != null && cidade == null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Todos os parâmetros definidos
            if (idade != null && estadoBR_sigla != null && cidade != null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Idade e cidade aleatória. Estado definido
            if (idade == null && estadoBR_sigla != null && cidade == null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Idade aleatória. Estado e cidade definida
            if (idade == null && estadoBR_sigla != null && cidade != null)
            {
                pessoa = await GetPessoa();
            }
            else
            // Todos os parametros aleatórios
            if (idade == null && estadoBR_sigla == null && cidade == null)
            {
                pessoa = await GetPessoa();
            }
            return pessoa;
        }

        public async Task<IEnumerable<Pessoa>> GerarListPessoaAsync(int quantidade = 1, int? idade = null, string estadoBR_sigla = null, string cidade = null, bool gerarComMascara = true)
        {
            List<Pessoa> pessoas = new();
            int cont = 0;

            while (true)
            {
                cont++;
                var pessoa = await GerarPessoaAsync(idade, estadoBR_sigla, cidade, gerarComMascara);
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