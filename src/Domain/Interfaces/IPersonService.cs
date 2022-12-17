namespace DocumentGeneratorApp.Domain;

public interface IPersonService
{
    /// <summary>
    /// Obtem um cadastro de uma pessoa aleat�ria
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<Person> GetRandomPersonAsync(GeneratePersonParameters parameters = default);

    /// <summary>
    /// Obtem uma lista de cadastro de pessoas aleat�rias
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<IEnumerable<Person>> GetRandomPersonListAsync(int quantity = 1, GeneratePersonParameters parameters = default);
}