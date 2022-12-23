using System.Text.Json.Serialization;

namespace DocumentGeneratorApp.Presentation.RestApi.Dtos;

public record PersonResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    [JsonPropertyName("rg")]
    public string Rg { get; set; }

    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("address")]
    public AddressResponse Address { get; set; }
}
