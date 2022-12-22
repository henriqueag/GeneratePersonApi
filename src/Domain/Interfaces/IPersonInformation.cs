namespace DocumentGeneratorApp.Domain;

public interface IPersonInformation
{
    /// <summary>
    /// Cria um email aleatório baseado no nome de entrada
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    string GenerateRandomEmail(string name);

    /// <summary>
    /// Obtém a data de nascimento baseado na idade informada
    /// </summary>
    /// <param name="age">Idade do usuário</param>
    /// <returns></returns>
    DateTime GetBirthDateByAge(int age);

    /// <summary>
    /// Cria uma data de nascimento aleátoria
    /// </summary>
    /// <param name="minAge">Idade mínina</param>
    /// <param name="maxAge">Idade máxima</param>
    /// <returns></returns>
    DateTime GenerateRandomBirthDate(int minAge, int maxAge);

    /// <summary>
    /// Obtém a idade calculada conforme a data de nascimento informada
    /// </summary>
    /// <param name="birthDate"></param>
    /// <returns></returns>
    int GetCalculatedAge(DateTime birthDate);

    /// <summary>
    /// Cria um telefone aleatório
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    string GenerateRandomPhone(string ddd);
}