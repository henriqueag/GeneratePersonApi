namespace DocumentGeneratorApp.Domain;

public interface IAddressService
{
    /// <summary>
    /// Obtém um endereço completo
    /// </summary>
    /// <param name="state">Sigla do estado</param>
    /// <param name="cityName">Nome da cidade</param>
    /// <returns></returns>
    Task<Address> GetAddressAsync(BrazilianStateAbbreviation state, string cityName);
}