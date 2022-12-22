using System.Globalization;
using System.Text;

namespace DocumentGeneratorApp.Domain;

public class PersonInformation : IPersonInformation
{
    private static readonly Random s_random = new();

    public DateTime GenerateRandomBirthDate(int minAge, int maxAge)
    {
        var initialYear = DateTime.Now.Year - maxAge;
        var finalYear = DateTime.Now.Year - minAge;

        var month = s_random.Next(1, 12);
        var day = s_random.Next(1, DateTime.DaysInMonth(DateTime.Now.Year, month));
        var year = s_random.Next(initialYear, finalYear);

        return new DateTime(year, month, day);
    }

    public string GenerateRandomEmail(string name)
    {
        var emailProviders = new string[] { "gmail", "yahoo", "hotmail", "outlook", "mail" };
        
        var normalizedNameArray = name.Normalize(NormalizationForm.FormD)
            .Where(IsLetterNonSpacingMark)
            .ToArray();

        var normalizedNameLower = new string(normalizedNameArray).ToLowerInvariant();
        var randomEmailProvider = emailProviders[s_random.Next(0, emailProviders.Length)];

        return string.Concat(normalizedNameLower, "@", randomEmailProvider, ".com");
    }

    public string GenerateRandomPhone(string ddd)
    {
        if (string.IsNullOrEmpty(ddd))
        {
            throw new ArgumentNullException(nameof(ddd));
        }

        var numberPrefix = new int[] { 999, 998, 988, 989, 987, 997 };
        var randomPrefix = numberPrefix[s_random.Next(0, numberPrefix.Length)];

        var stringBuilder = new StringBuilder();
        stringBuilder.Append(ddd);
        stringBuilder.Append(randomPrefix);

        for (int i = 0; i < 6; i++)
        {
            var toNextNumbers = s_random.Next(0, 9);
            stringBuilder.Append(toNextNumbers);
        }

        var phoneWithMaskResult = stringBuilder.ToString()
            .Insert(0, "(")
            .Insert(3, ") ")
            .Insert(10, "-");

        return phoneWithMaskResult;
    }

    public DateTime GetBirthDateByAge(int age)
    {
        var birthDateResult = default(DateTime);

        while (birthDateResult.Day < DateTime.Now.Day && birthDateResult.Month != DateTime.Now.Month)
        {
            var birthYear = DateTime.Now.Year - age;
            var birthMonth = DateTime.Now.Month == 12
                ? s_random.Next(1, DateTime.Now.Month)
                : s_random.Next(1, DateTime.Now.Month + 1);

            var birthDay = s_random.Next(1, DateTime.DaysInMonth(birthYear, birthMonth));
            
            birthDateResult = new DateTime(birthYear, birthMonth, birthDay);
        }

        return birthDateResult;
    }

    public int GetCalculatedAge(DateTime birthDate)
    {
        var birthDateSubtractResult = DateTime.Now.Subtract(birthDate);

        var totalDays = birthDateSubtractResult.TotalDays;
        var age = totalDays / 365.2596;

        if (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day)
        {
            age--;
        }

        return Convert.ToInt32(age);
    }

    private static bool IsLetterNonSpacingMark(char ch)
    {
        var isLetter = char.GetUnicodeCategory(ch) is (UnicodeCategory.UppercaseLetter or UnicodeCategory.LowercaseLetter);
        var hasSpacingMark = char.GetUnicodeCategory(ch) is UnicodeCategory.NonSpacingMark;

        return isLetter && !hasSpacingMark;
    }
}
