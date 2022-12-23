using DocumentGeneratorApp.Domain;
using DocumentGeneratorApp.Infrastructure.ExternalApi.Dtos;
using Mapster;
using System.Text.Json;

namespace DocumentGeneratorApp.Infrastructure.ExternalApi;

public class AddressDetailService : IAddressDetailService
{
    private const string _namedHttpClient = "addressByCep";

    private readonly IHttpClientFactory _factory;

    public AddressDetailService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<Address> GetAddressByCepAsync(string cep, CancellationToken cancellationToken)
    {
        var requestUri = string.Concat("http://viacep.com.br/ws/", cep, "/json");
        var httpClient = _factory.CreateClient(_namedHttpClient);

        var response = await httpClient.GetStringAsync(requestUri, cancellationToken);
        
        var addressResponse = JsonSerializer.Deserialize<AddressResponse>(response);

        return addressResponse?.Adapt<Address>();
    }
}
