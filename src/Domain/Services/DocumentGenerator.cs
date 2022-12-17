namespace DocumentGeneratorApp.Domain;

public class DocumentGenerator : IDocumentGenerator
{
    public string GenerateCnpj(bool withMask = true)
    {
        throw new NotImplementedException();
    }

    public string GenerateCpf(BrazilianStateAbbreviation state, bool withMask = true)
    {
        throw new NotImplementedException();
    }

    public string GenerateRg(bool withMask = true)
    {
        throw new NotImplementedException();
    }
}