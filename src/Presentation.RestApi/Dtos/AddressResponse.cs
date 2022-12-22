using System.Text.Json.Serialization;

namespace DocumentGeneratorApp.Presentation.RestApi.Dtos;

/// <summary>
/// Representa a resposta da requisição de geração de endereço
/// </summary>
public record AddressResponse
{
    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("district")]
    public string District { get; set; }
    
    [JsonPropertyName("complement")]
    public string Complement { get; set; }
    
    [JsonPropertyName("city")]
    public string City { get; set; }
    
    [JsonPropertyName("cep")]
    public string Cep { get; set; }
    
    [JsonPropertyName("state")]
    public string State { get; set; }
    
    [JsonPropertyName("ddd")]
    public string Ddd { get; set; }
}
