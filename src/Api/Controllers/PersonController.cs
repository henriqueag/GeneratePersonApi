using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DocumentGeneratorApp.Api.Controllers;

/// <summary>
/// Api que disponibiliza funções para gerar cadastros aleatórios de pessoas
/// </summary>
[ApiController]
[Route(_route)]
public class PersonController : ControllerBase
{
    private const string _route = "api/person";

    [HttpGet("one-person")]
    public async Task<IActionResult> GetOneAsync()
    {
        return Ok();
    }

    [HttpGet("list-person")]
    public async Task<IActionResult> GetListAsync()
    {
        return Ok();
    }
}
