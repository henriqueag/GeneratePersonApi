using System.Collections.Generic;
using System.Threading.Tasks;
using GeneratePersonApi.Entities;
using GeneratePersonApi.Entities.Enum;

namespace GeneratePersonApi.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> GetEnderecoAsync(EstadosBR? estado = null, string cityName = null);
        IList<string> GetCidades(EstadosBR? estado);
        IList<string> GetEstados();
    }
}
