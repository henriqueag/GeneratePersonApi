namespace DocumentGeneratorApp.Presentation.RestApi.Controllers;

/// <summary>
/// Api que disponibiliza funções de geração de documentos válidos
/// </summary>
[Route(_route)]
public class DocumentController : AbstractController
{
    private const string _route = "api/document";

    private readonly IDocumentGenerator _generator;

    public DocumentController(IDocumentGenerator generator, ILogger<AbstractController> logger) 
        : base(logger)
    {
        _generator = generator;
    }

    /// <summary>
    /// Obtém um cpf válido conforme o estado brasileiro informado
    /// </summary>
    /// <param name="abbreviationState">A sigla de qualquer estado brasileiro existente</param>
    /// <param name="withMask">Determina se o resultado terá mascara de cpf ou não</param>
    /// <returns></returns>
    [HttpGet("generate-cpf")]
    public IActionResult GetCpf([FromQuery] BrazilianStateAbbreviation abbreviationState, [FromQuery] bool withMask = true)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para obter um cpf aleatório do estado de {BrasilianState}",
            Request.Method, Request.Path.Value, abbreviationState);

        var result = _generator.GenerateCpf(abbreviationState, withMask: withMask);

        return Ok(new { Cpf = result });
    }

    /// <summary>
    /// Obtém um cnpj válido
    /// </summary>
    /// <param name="withMask">Determina se o resultado terá mascara de cnpj ou não</param>
    /// <returns></returns>
    [HttpGet("generate-cnpj")]
    public IActionResult GetCnpj([FromQuery] bool withMask = true)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para obter um cnpj aleatório",
            Request.Method, Request.Path.Value);

        var result = _generator.GenerateCnpj(withMask: withMask);

        return Ok(new { Cnpj = result });
    }

    /// <summary>
    /// Obtém um registo geral(RG) válido
    /// </summary>
    /// <returns></returns>
    [HttpGet("generate-rg")]
    public IActionResult GetRg([FromQuery] bool withMask = true)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para obter um registro geral(RG) aleatório",
            Request.Method, Request.Path.Value);

        var result = _generator.GenerateRg(withMask: withMask);

        return Ok(new { Rg = result });
    }
}
