namespace DocumentGeneratorApp.Presentation.RestApi.Controllers;

/// <summary>
/// Api que disponibiliza funções de validação de documentos
/// </summary>
[Route(_route)]
public class ValidatorController : AbstractController
{
    private const string _route = "api/validator";

    private readonly IDocumentValidator _validator;

    public ValidatorController(IDocumentValidator validator, ILogger<AbstractController> logger) 
        : base(logger)
    {
        _validator = validator;
    }

    /// <summary>
    /// Faz a validação de um cpf
    /// </summary>
    /// <param name="cpf">Cpf para validação</param>
    /// <returns></returns>
    [HttpPost("cpf")]
    public IActionResult ValidateCpf([FromQuery] string cpf)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para validar se o cpf {Cpf} é válido",
            Request.Method, Request.Path.Value, cpf);

        var result = new
        {
            TargetCpf = cpf,
            IsValid = _validator.ValidateCpf(cpf)
        };

        return Ok(result);
    }

    /// <summary>
    /// Faz a validação de um cnpj
    /// </summary>
    /// <param name="cnpj">Cnpj para validação</param>
    /// <returns></returns>
    [HttpPost("cnpj")]
    public IActionResult ValidateCnpj([FromQuery] string cnpj)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para validar se o cnpj {Cnpj} é válido",
            Request.Method, Request.Path.Value, cnpj);

        var result = new
        {
            TargetCnpj = cnpj,
            IsValid = _validator.ValidateCnpj(cnpj)
        };

        return Ok(result);
    }

    /// <summary>
    /// Faz a validação de um registro geral(RG)
    /// </summary>
    /// <param name="rg"></param>
    /// <returns></returns>
    [HttpPost("rg")]
    public IActionResult ValidateRg([FromQuery] string rg)
    {
        return Ok();
    }
}
