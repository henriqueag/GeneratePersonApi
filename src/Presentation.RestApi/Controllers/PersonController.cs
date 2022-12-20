namespace DocumentGeneratorApp.Presentation.RestApi.Controllers;

/// <summary>
/// Api que disponibiliza funções para gerar cadastros aleatórios de pessoas
/// </summary>
[Route(_route)]
public class PersonController : AbstractController
{
    private const string _route = "api/person";

    public PersonController(ILogger<AbstractController> logger) 
        : base(logger)
    {
    }

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
