using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentGenerator.Entities;
using DocumentGenerator.Entities.Enum;

namespace DocumentGenerator.Lib.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> GetEnderecoAsync(EstadosBR? estado = null, string cityName = null);
        IList<string> GetCidades(EstadosBR? estado);
        IList<string> GetEstados();
    }
}
