namespace DocumentGeneratorApp.Domain;

public interface IAddressRepository
{
    /// <summary>
    /// Obtém as cidades existentes para o estado brasileiro informado
    /// </summary>
    /// <param name="brazilianState"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<string>> GetCitiesAsync(string brazilianState, CancellationToken cancellationToken);

    /// <summary>
    /// Obtém uma lista com os estados brasileiros
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<BrazilianStates>> GetBrazilianStatesAsync(CancellationToken cancellationToken);
}
