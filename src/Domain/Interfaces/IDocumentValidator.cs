namespace DocumentGeneratorApp.Domain;

public interface IDocumentValidator
{
    /// <summary>
    /// Faz a validação de um cpf
    /// </summary>
    /// <param name="cpf">O cpf para validação</param>
    /// <returns></returns>
    bool ValidateCpf(string cpf);

    /// <summary>
    /// Faz a validação de um cnpj
    /// </summary>
    /// <param name="cnpj">O cnpj para validação</param>
    /// <returns></returns>
    bool ValidateCnpj(string cnpj);

    /// <summary>
    /// Faz a validação de um Registro Geral(RG)
    /// </summary>
    /// <param name="rg">O rg para validação</param>
    /// <returns></returns>
    bool ValidateRg(string rg);
}