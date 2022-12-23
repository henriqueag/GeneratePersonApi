using System.Text.Json.Serialization;

namespace DocumentGeneratorApp.Presentation.RestApi.Dtos;

public record PersonParametersRequest
{
    [JsonPropertyName("minAge")]
    public int? MinAge { get; set; }

    [JsonPropertyName("maxAge")]
    public int? MaxAge { get; set; }

    [JsonPropertyName("state")]
    public BrazilianStateAbbreviation? State { get; set; }

    [JsonPropertyName("cityName")]
    public string CityName { get; set; }
}
