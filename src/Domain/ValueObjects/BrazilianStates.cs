namespace DocumentGeneratorApp.Domain;

public class BrazilianStates
{
    public BrazilianStates(string name, string abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
    }

    public string Name { get; }
    public string Abbreviation { get; }
}