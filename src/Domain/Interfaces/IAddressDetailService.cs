namespace DocumentGeneratorApp.Domain;

public interface IAddressDetailService
{
    /// <summary>
    /// Obtém um endereço através do CEP
    /// </summary>
    /// <param name="cep"></param>
    /// <returns></returns>
    Task<Address> GetAddressByCepAsync(string cep, CancellationToken cancellationToken);
}
