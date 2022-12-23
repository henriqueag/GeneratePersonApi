using DocumentGeneratorApp.Domain.ValueObjects;
using DocumentGeneratorApp.Presentation.RestApi.Dtos;
using Mapster;

namespace DocumentGeneratorApp.Presentation.RestApi.Controllers;

/// <summary>
/// Api que disponibiliza funções para gerar cadastros aleatórios de pessoas
/// </summary>
[Route(_route)]
public class PersonController : AbstractController
{
    private const string _route = "api/person";

    private readonly IPersonService _service;

    public PersonController(IPersonService service, ILogger<AbstractController> logger) 
        : base(logger)
    {
        _service = service;
    }

    [HttpPost("one-person")]
    public async Task<IActionResult> GetOneAsync([FromBody] PersonParametersRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para obter um cadastro aleatório de pessoa",
            Request.Method, Request.Path.Value);

        var addressConditions = new RandomAddressConditions(request.State, request.CityName);
        var parameters = new GeneratePersonParameters(request.MinAge, request.MaxAge, addressConditions);
        var result = await _service.GetRandomPersonAsync(parameters, cancellationToken);
        
        return Ok(result.Adapt<PersonResponse>());
    }

    [HttpPost("list-person/{quantity:int}")]
    public async Task<IActionResult> GetListAsync([FromRoute] int quantity, [FromBody] PersonParametersRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para obter uma lista com {Quantity} de cadastros aleatórios de pessoas",
            Request.Method, Request.Path.Value, quantity);

        var addressConditions = new RandomAddressConditions(request.State, request.CityName);
        var parameters = new GeneratePersonParameters(request.MinAge, request.MaxAge, addressConditions);
        var result = await _service.GetRandomPersonListAsync(parameters, cancellationToken, quantity);

        return Ok(result.Adapt<IEnumerable<PersonResponse>>());
    }
}
