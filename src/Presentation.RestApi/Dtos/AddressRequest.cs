using System.Text.Json.Serialization;

namespace DocumentGeneratorApp.Presentation.RestApi.Dtos;

/// <summary>
/// Representa o objeto da requisição para condições de geração de um endereço
/// </summary>
public record AddressRequest 
{
    [JsonPropertyName("state")]
    public BrazilianStateAbbreviation? State { get; set; }

    [JsonPropertyName("cityName")]
    public string CityName { get; set; }
}
