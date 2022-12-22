namespace DocumentGeneratorApp.Domain.ValueObjects;

public record RandomAddressConditions
{
    public static readonly RandomAddressConditions Default = new(state: null, cityName: null);

    public RandomAddressConditions(BrazilianStateAbbreviation? state, string cityName)
    {        
        State = state;
        CityName = cityName;

        TotallyRandom = state is null && string.IsNullOrEmpty(cityName);
        DefinedStateAndUndefinedCity = state is not null && string.IsNullOrEmpty(cityName);
        DefinedStateAndCity = state is not null && !string.IsNullOrEmpty(cityName);
    }

    public BrazilianStateAbbreviation? State { get; }
    public string CityName { get; }

    public bool TotallyRandom { get; }
    public bool DefinedStateAndUndefinedCity { get; }
    public bool DefinedStateAndCity { get; }
}
