namespace DocumentGeneratorApp.Domain;

public interface IDocumentGenerator
{
    /// <summary>
    /// Cria um CNPJ válido
    /// </summary>
    /// <param name="withMask">Define se terá a máscara do cnpj</param>
    /// <returns></returns>
    string GenerateCnpj(bool withMask = true);

    /// <summary>
    /// Cria um CPF válido
    /// </summary>
    /// <param name="state">Estado brasileiro que o cpf será gerado</param>
    /// <param name="withMask">Define se terá a máscara do cpf</param>
    /// <returns></returns>
    string GenerateCpf(BrazilianStateAbbreviation state, bool withMask = true);

    /// <summary>
    /// Cria um Registro Geral(RG) válido
    /// </summary>
    /// <param name="withMask">Define se terá a máscara do RG</param>
    /// <returns></returns>
    string GenerateRg(bool withMask = true);
}