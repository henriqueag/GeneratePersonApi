using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentGenerator.Api.Entities;

namespace DocumentGenerator.Api.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> GetEnderecoAsync(string estadoBR_sigla = null, string cityName = null);
        IList<string> GetCidades(string estadoBR_sigla);
        IList<EstadosBR> GetEstados();
    }
}
