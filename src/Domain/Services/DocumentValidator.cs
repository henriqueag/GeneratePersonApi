using System.Globalization;
using System.Text.RegularExpressions;

namespace DocumentGeneratorApp.Domain;

public class DocumentValidator : IDocumentValidator
{
    private const string _repeatedNumberPatternForCpf = @"1{11}|2{11}|3{11}|4{11}|5{11}|6{11}|7{11}|8{11}|9{11}|0{11}";
    private const string _repeatedNumberPatternForCnpj = @"1{14}|2{14}|3{14}|4{14}|5{14}|6{14}|7{14}|8{14}|9{14}|0{14}";

    public bool ValidateCnpj(string cnpj)
    {
        var cnpjOnlyNumbers = GetOnlyNumbers(cnpj);

        if (cnpjOnlyNumbers.Length != 14)
        {
            return false;
        }

        var areRepeatedNumbers = new Regex(_repeatedNumberPatternForCnpj).IsMatch(cnpjOnlyNumbers);
        if (areRepeatedNumbers)
        {
            return false;
        }

        var firstDigit = GetCpnjFirstDigit(cnpjOnlyNumbers);
        var secondDigit = GetCpnjSecondDigit(cnpjOnlyNumbers);

        var checkFirstDigit = int.Parse(cnpjOnlyNumbers.Substring(cnpjOnlyNumbers.Length - 2, 1)) == firstDigit;
        var checkSecondDigit = int.Parse(cnpjOnlyNumbers.Substring(cnpjOnlyNumbers.Length - 1, 1)) == secondDigit;

        return checkFirstDigit && checkSecondDigit;        
    }

    public bool ValidateCpf(string cpf)
    {
        var cpfOnlyNumbers = GetOnlyNumbers(cpf);

        if (cpfOnlyNumbers.Length != 11) 
        {
            return false;
        }

        var areRepeatedNumbers = new Regex(_repeatedNumberPatternForCpf).IsMatch(cpfOnlyNumbers);
        if (areRepeatedNumbers)
        {
            return false;
        }

        var firstDigit = GetCpfFirstDigit(cpfOnlyNumbers);
        var secondDigit = GetCpfSecondDigit(cpfOnlyNumbers);

        var checkfirstDigit = int.Parse(cpfOnlyNumbers.Substring(cpfOnlyNumbers.Length - 2, 1)) == firstDigit;
        var checksecondDigit = int.Parse(cpfOnlyNumbers.Substring(cpfOnlyNumbers.Length - 1, 1)) == secondDigit;

        return checkfirstDigit && checksecondDigit;
    }

    public bool ValidateRg(string rg)
    {
        throw new NotImplementedException();
    }

    private static string GetOnlyNumbers(string input)
    {
        var charResult = input.Where(ch => char.GetUnicodeCategory(ch) == UnicodeCategory.DecimalDigitNumber).ToArray();
        
        return new string(charResult);
    }

    private static int GetCpfFirstDigit(string cpf) 
    {
        int firstDigit = 0;
        int multiplier = 10;

        for (int i = 0; i < 9; i++)
        {
            int convertedDigit = int.Parse($"{cpf[i]}");
            firstDigit += convertedDigit * multiplier;

            multiplier--;
        }

        var result = 11 - (firstDigit %= 11);

        return result >= 10 ? 0 : result;
    }
    
    private static int GetCpfSecondDigit(string cpf) 
    {
        int secondDigit = 0;
        int multiplier = 11;

        for (int i = 0; i < 10; i++)
        {
            int convertedDigit = int.Parse($"{cpf[i]}");
            secondDigit += convertedDigit * multiplier;

            multiplier--;
        }

        var result = 11 - (secondDigit % 11);

        return result >= 10 ? 0 : result;
    }

    private static int GetCpnjFirstDigit(string cnpj)
    {
        int firstDigit = 0;
        int multiplier = 6;

        for (int i = 0; i < cnpj.Length; i++)
        {
            int convertedDigit = int.Parse($"{cnpj[i]}");
            firstDigit += convertedDigit * multiplier;
            multiplier++;

            if (i == 3)
            {
                multiplier = 2;
            }

            if (i == 11)
            {
                firstDigit %= 11;
                if (firstDigit == 10)
                {
                    firstDigit = 0;
                }

                break;
            }
        }

        return firstDigit;
    }

    private static int GetCpnjSecondDigit(string cnpj)
    {
        int secondDigit = 0;
        int multiplier = 5;

        for (int i = 0; i < cnpj.Length; i++)
        {
            int convertedDigit = int.Parse($"{cnpj[i]}");
            secondDigit += convertedDigit * multiplier;
            multiplier++;

            if (i == 4)
            {
                multiplier = 2;
            }

            if (i == 12)
            {
                secondDigit %= 11;
                break;
            }
        }

        return secondDigit;
    }
}