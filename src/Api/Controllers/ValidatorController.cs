using Microsoft.AspNetCore.Mvc;

namespace DocumentGeneratorApp.Api.Controllers;

/// <summary>
/// Api que disponibiliza funções de validação de documentos
/// </summary>
[ApiController]
[Route(_route)]
public class ValidatorController : ControllerBase
{
    private const string _route = "api/validator";

    /// <summary>
    /// Faz a validação de um cpf
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    [HttpGet("cpf")]
    public IActionResult ValidateCpf(string cpf)
    {
        return Ok();
    }

    /// <summary>
    /// Faz a validação de um cnpj
    /// </summary>
    /// <param name="cnpj"></param>
    /// <returns></returns>
    [HttpGet("cnpj")]
    public IActionResult ValidateCnpj(string cnpj)
    {
        return Ok();
    }

    /// <summary>
    /// Faz a validação de um registro geral(RG)
    /// </summary>
    /// <param name="rg"></param>
    /// <returns></returns>
    [HttpGet("rg")]
    public IActionResult ValidateRg(string rg)
    {
        return Ok();
    }
}
