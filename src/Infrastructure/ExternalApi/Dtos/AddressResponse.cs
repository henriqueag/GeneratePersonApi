using System.Text.Json.Serialization;

namespace DocumentGeneratorApp.Infrastructure.ExternalApi.Dtos;

public record AddressResponse
{
    [JsonPropertyName("cep")]
    public string Cep { get; set; }

    [JsonPropertyName("logradouro")]
    public string Street { get; set; }

    [JsonPropertyName("complemento")]
    public string Complement { get; set; }

    [JsonPropertyName("bairro")]
    public string District { get; set; }

    [JsonPropertyName("localidade")]
    public string City { get; set; }

    [JsonPropertyName("uf")]
    public string State { get; set; }

    [JsonPropertyName("ddd")]
    public string Ddd { get; set; }
}
