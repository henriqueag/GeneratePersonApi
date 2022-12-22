using System.Text.Json.Serialization;

namespace DocumentGeneratorApp.Presentation.RestApi.Dtos;

/// <summary>
/// Representa a resposta da requisição de busca de estados brasileiros
/// </summary>
public record BrazilianStateResponse
{
    [JsonPropertyName("capital")]
    public string Name { get; set; }

    [JsonPropertyName("abbreviationState")]
    public string Abbreviation { get; set; }
}
