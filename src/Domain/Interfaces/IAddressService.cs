using DocumentGeneratorApp.Domain.ValueObjects;

namespace DocumentGeneratorApp.Domain;

public interface IAddressService
{
    /// <summary>
    /// Obt�m um endere�o completo
    /// </summary>
    /// <param name="state">Sigla do estado</param>
    /// <param name="cityName">Nome da cidade</param>
    /// <returns></returns>
    Task<Address> GetAddressAsync(RandomAddressConditions randomConditions, CancellationToken cancellationToken);
}