namespace DocumentGeneratorApp.Domain;

public interface IPersonService
{
    /// <summary>
    /// Obtem um cadastro de uma pessoa aleatória
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<Person> GetRandomPersonAsync(GeneratePersonParameters parameters = default);

    /// <summary>
    /// Obtem uma lista de cadastro de pessoas aleatórias
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<IEnumerable<Person>> GetRandomPersonListAsync(int quantity = 1, GeneratePersonParameters parameters = default);
}