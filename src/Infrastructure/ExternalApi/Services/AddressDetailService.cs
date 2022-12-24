using DocumentGeneratorApp.Domain;
using DocumentGeneratorApp.Infrastructure.ExternalApi.Dtos;
using Mapster;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DocumentGeneratorApp.Infrastructure.ExternalApi;

public class AddressDetailService : IAddressDetailService
{
    private const string _namedHttpClient = "addressByCep";

    private readonly IHttpClientFactory _factory;
    private readonly ILogger<AddressDetailService> _logger;

    public AddressDetailService(IHttpClientFactory factory, ILogger<AddressDetailService> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public async Task<Address> GetAddressByCepAsync(string cep, CancellationToken cancellationToken)
    {
        var requestUri = string.Concat("http://viacep.com.br/ws/", cep, "/json");
        var httpClient = _factory.CreateClient(_namedHttpClient);

        try
        {
            var response = await httpClient.GetStringAsync(requestUri, cancellationToken);

            var addressResponse = JsonSerializer.Deserialize<AddressResponse>(response);

            return addressResponse?.Adapt<Address>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, "Status Code: {StatusCode}; Message: {Message}", 
                httpEx.StatusCode, httpEx.Message);

            return null;
        }
        catch(JsonException jsonEx)
        {
            _logger.LogError(jsonEx, "Message: {Message}", jsonEx.Message);

            return null;
        }
    }
}