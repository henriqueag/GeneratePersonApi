namespace DocumentGeneratorApp.Domain;

public class BrazilianState
{
    public BrazilianState(string name, string abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
    }

    public string Name { get; }
    public string Abbreviation { get; }
}