namespace DocumentGeneratorApp.Domain;

public interface IAddressRepository
{
    /// <summary>
    /// Obtém as cidades existentes para o estado brasileiro informado
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    Task<IEnumerable<string>> GetCities(BrazilianStateAbbreviation state, CancellationToken cancellationToken);

    /// <summary>
    /// Obtém uma lista com os estados brasileiros
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<BrazilianStates>> GetBrazilianStates(CancellationToken cancellationToken);
}
