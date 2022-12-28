using DocumentGeneratorApp.Domain.ValueObjects;
using DocumentGeneratorApp.Presentation.RestApi.Dtos;
using Mapster;

namespace DocumentGeneratorApp.Presentation.RestApi.Controllers;

/// <summary>
/// Api que disponibiliza funções para obtenção de endereços do Brasil
/// </summary>
[Route(_route)]
public class AddressController : AbstractController
{
    private const string _route = "api/address";

    private readonly IAddressRepository _repository;
    private readonly IAddressService _service;

    public AddressController(IAddressRepository repository, IAddressService service, ILogger<AbstractController> logger) 
        : base(logger)
    {
        _repository = repository;
        _service = service;
    }

    /// <summary>
    /// Obtém um endereço conforme o estado e a cidade informada
    /// </summary>
    /// <param name="request">Corpo da requisição com nome do estado e cidade para preencher</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns></returns>
    [HttpPost("brazilian-address")]
    public async Task<IActionResult> GetAddressAsync([FromBody] AddressRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para obter um endereço conforme as condições {@Conditions}",
            Request.Method, Request.Path.Value, new { request.State, request.CityName });

        var conditions = new RandomAddressConditions(request.State, request.CityName);
        var result = await _service.GetAddressAsync(conditions, cancellationToken);
                
        return Ok(result.Adapt<AddressResponse>());
    }

    /// <summary>
    /// Obtém todas as cidades relacionadas ao estado brasileiro informado
    /// </summary>
    /// <param name="abbreviationState">A sigla de qualquer estado brasileiro existente</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns></returns>
    [HttpGet("brazilian-cities")]
    public async Task<IActionResult> GetCitiesAsync([FromQuery] BrazilianStateAbbreviation abbreviationState, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para obter cidades para o estado de {BrasilianState}",
            Request.Method, Request.Path.Value, abbreviationState);

        var result = await _repository.GetCitiesAsync(abbreviationState.ToString(), cancellationToken);

        return Ok(new { Cities = result });
    }

    /// <summary>
    /// Obtém uma lista com todos os estados brasileiros
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns></returns>
    [HttpGet("brazilian-states")]
    public async Task<IActionResult> GetBrasilianStatesAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requisição {RequestVerb} {RequestUrl} para obter os estados do Brasil",
            Request.Method, Request.Path.Value);

        var result = await _service.GetBrazilianStatesAsync(cancellationToken);
        var resultSorted = result.OrderBy(x => x.Abbreviation);

        return Ok(resultSorted.Adapt<IEnumerable<BrazilianStateResponse>>());
    }
}