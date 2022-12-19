using Microsoft.AspNetCore.Mvc;

namespace DocumentGeneratorApp.Api.Controllers;

/// <summary>
/// Api que disponibiliza funções de geração de documentos válidos
/// </summary>
[ApiController]
[Route(_route)]
public class DocumentController : ControllerBase
{
    private const string _route = "api/document";

    /// <summary>
    /// Obtém um cpf válido conforme o estado brasileiro informado
    /// </summary>
    /// <param name="abbreviationState">A sigla de qualquer estado brasileiro existente</param>
    /// <returns></returns>
    [HttpGet("generate-cpf")]
    public IActionResult GetCpf([FromQuery] string abbreviationState)
    {
        return Ok();
    }

    /// <summary>
    /// Obtém um cnpj válido
    /// </summary>
    /// <returns></returns>
    [HttpGet("generate-cnpj")]
    public IActionResult GetCnpj()
    {
        return Ok();
    }

    /// <summary>
    /// Obtém um registo geral(RG) válido
    /// </summary>
    /// <returns></returns>
    [HttpGet("generate-rg")]
    public IActionResult GetRg()
    {
        return Ok();
    }
}
