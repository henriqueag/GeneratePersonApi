namespace DocumentGeneratorApp.Domain;

public interface IPersonService
{
    /// <summary>
    /// Obtem um cadastro de uma pessoa aleatória
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<Person> GetRandomPersonAsync(GeneratePersonParameters parameters, CancellationToken cancellationToken);

    /// <summary>
    /// Obtem uma lista de cadastro de pessoas aleatórias
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    Task<IEnumerable<Person>> GetRandomPersonListAsync(GeneratePersonParameters parameters, CancellationToken cancellationToken, int quantity = 1);
}