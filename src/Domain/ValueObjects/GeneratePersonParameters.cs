namespace DocumentGeneratorApp.Domain;

public record GeneratePersonParameters
{
    public GeneratePersonParameters(int? age, string city, BrazilianStateAbbreviation state)
    {
        Age = age;
        City = city;
        State = state;
    }

    public int? Age { get; }
    public string City { get; }
    public BrazilianStateAbbreviation State { get; }
}