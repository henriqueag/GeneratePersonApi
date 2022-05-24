using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentGenerator.Api.Entities;
using DocumentGenerator.Api.Entities.Enum;

namespace DocumentGenerator.Api.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> GetEnderecoAsync(EstadosBR? estado = null, string cityName = null);
        IList<string> GetCidades(EstadosBR? estado);
        IList<string> GetEstados();
    }
}
