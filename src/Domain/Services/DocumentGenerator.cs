using System.Text;

namespace DocumentGeneratorApp.Domain;

public class DocumentGenerator : IDocumentGenerator
{
    private static readonly Random s_random = new();

    private readonly IDocumentValidator _validator;

    public DocumentGenerator(IDocumentValidator validator)
    {
        _validator = validator;
    }

    public string GenerateCnpj(bool withMask = true)
    {
        var cnpjResult = new StringBuilder();
        while (!_validator.ValidateCnpj(cnpjResult.ToString()))
        {
            cnpjResult.Clear();

            for (int i = 0; i < 10; i++)
            {
                cnpjResult.Append(s_random.Next(0, 9));
                if (cnpjResult.Length == 8)
                {
                    cnpjResult.Append("0001");
                }
            }
        }

        if(withMask)
        {
            return cnpjResult.ToString()
                .Insert(2, ".")
                .Insert(6, ".")
                .Insert(10, "/")
                .Insert(15, "-");
        }

        return cnpjResult.ToString();
    }

    public string GenerateCpf(BrazilianStateAbbreviation state, bool withMask = true)
    {
        var cpfResult = new StringBuilder();
        while (!_validator.ValidateCpf(cpfResult.ToString()))
        {
            cpfResult.Clear();

            for (int i = 0; i < 10; i++)
            {
                cpfResult.Append(s_random.Next(0, 9));
                if (cpfResult.Length == 8)
                {
                    cpfResult.Append(GetCpfDigitByBrasilianState(state));
                }
            }
        }

        if(withMask)
        {
            return cpfResult.ToString()
                .Insert(3, ".")
                .Insert(7, ".")
                .Insert(11, "-");
        }

        return cpfResult.ToString();
    }

    public string GenerateRg(bool withMask = true)
    {
        var rgResult = new StringBuilder();
        while (!_validator.ValidateRg(rgResult.ToString()))
        {
            rgResult.Clear();

            for (int i = 0; i < 9; i++)
            {
                rgResult.Append(s_random.Next(0, 9));
            }
        }
        
        if (withMask)
        {
            return rgResult.ToString()
                .Insert(2, ".")
                .Insert(6, ".")
                .Insert(10, "-");
        }

        return rgResult.ToString();
    }

    private static int GetCpfDigitByBrasilianState(BrazilianStateAbbreviation state)
    {
        return state switch
        {
            BrazilianStateAbbreviation.DF => 1,
            BrazilianStateAbbreviation.GO => 1,
            BrazilianStateAbbreviation.MT => 1,
            BrazilianStateAbbreviation.MS => 1,
            BrazilianStateAbbreviation.TO => 1,

            BrazilianStateAbbreviation.AM => 2,
            BrazilianStateAbbreviation.PA => 2,
            BrazilianStateAbbreviation.RR => 2,
            BrazilianStateAbbreviation.AP => 2,
            BrazilianStateAbbreviation.AC => 2,
            BrazilianStateAbbreviation.RO => 2,

            BrazilianStateAbbreviation.CE => 3,
            BrazilianStateAbbreviation.MA => 3,
            BrazilianStateAbbreviation.PI => 3,

            BrazilianStateAbbreviation.AL => 4,
            BrazilianStateAbbreviation.PB => 4,
            BrazilianStateAbbreviation.PE => 4,
            BrazilianStateAbbreviation.RN => 4,

            BrazilianStateAbbreviation.BA => 5,
            BrazilianStateAbbreviation.SE => 5,

            BrazilianStateAbbreviation.MG => 6,
            BrazilianStateAbbreviation.RJ => 7,
            BrazilianStateAbbreviation.ES => 7,
            BrazilianStateAbbreviation.SP => 8,

            BrazilianStateAbbreviation.RS => 0,
            BrazilianStateAbbreviation.PR => 9,
            BrazilianStateAbbreviation.SC => 9,

            _ => throw new ArgumentOutOfRangeException(nameof(state), state.ToString())
        };
    }
}