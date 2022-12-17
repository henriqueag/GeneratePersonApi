namespace DocumentGeneratorApp.Domain;

public class PersonService : IPersonService
{
    public Task<Person> GetRandomPersonAsync(GeneratePersonParameters parameters = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Person>> GetRandomPersonListAsync(int quantity = 1, GeneratePersonParameters parameters = null)
    {
        throw new NotImplementedException();
    }
}
