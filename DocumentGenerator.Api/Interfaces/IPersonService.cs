using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentGenerator.Api.Entities;

namespace DocumentGenerator.Api.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Pessoa>> GerarListPessoaAsync(int quantidade = 1, int? idade = null, string estadoBR_sigla = null, string cidade = null, bool gerarComPonto = true);
        Task<Pessoa> GerarPessoaAsync(int? idade = null, string estadoBR_sigla = null, string cidade = null, bool gerarComPonto = true);
    }
}