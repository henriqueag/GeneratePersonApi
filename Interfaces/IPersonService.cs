using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentGenerator.Entities;
using DocumentGenerator.Entities.Enum;

namespace DocumentGenerator.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Pessoa>> GerarListPessoaAsync(int quantidade = 1, int? idade = null, EstadosBR? estado = null, string cidade = null, bool gerarComPonto = true);
        Task<Pessoa> GerarPessoaAsync(int? idade = null, EstadosBR? estado = null, string cidade = null, bool gerarComPonto = true);
    }
}