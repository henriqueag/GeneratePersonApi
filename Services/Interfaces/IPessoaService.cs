using System.Collections.Generic;
using System.Threading.Tasks;
using GeneratePersonApi.Entities;
using GeneratePersonApi.Entities.Enum;

namespace GeneratePersonApi.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GerarListPessoaAsync(int quantidade = 1, int? idade = null, EstadosBR? estado = null, string cidade = null, bool gerarComPonto = true);
        Task<Pessoa> GerarPessoaAsync(int? idade = null, EstadosBR? estado = null, string cidade = null, bool gerarComPonto = true);
    }
}