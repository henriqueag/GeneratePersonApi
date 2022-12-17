namespace DocumentGeneratorApp.Domain;

public class PersonInformation : IPersonInformation
{
    public DateTime GenerateRandomBirthDate(int minAge = 18, int maxAge = 89)
    {
        throw new NotImplementedException();
    }

    public string GenerateRandomEmail(string name)
    {
        throw new NotImplementedException();
    }

    public string GenerateRandomPhone(Address address)
    {
        throw new NotImplementedException();
    }

    public DateTime GetBirthDateByAge(int age)
    {
        throw new NotImplementedException();
    }

    public int GetCalculatedAge(DateTime birthDate)
    {
        throw new NotImplementedException();
    }
}
