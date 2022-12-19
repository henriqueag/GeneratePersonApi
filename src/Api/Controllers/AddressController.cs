namespace DocumentGeneratorApp.Api.Controllers;

/// <summary>
/// Api que disponibiliza funções para obtenção de endereços do Brasil
/// </summary>
[ApiController]
[Route(_route)]
public class AddressController : ControllerBase
{
    private const string _route = "api/address";

    private readonly IAddressRepository _repository;
    private readonly ILogger<AddressController> _logger;

    public AddressController(IAddressRepository repository, ILogger<AddressController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// Obtém um endereço conforme o estado e a cidade informada
    /// </summary>
    /// <param name="abbreviationState">A sigla de qualquer estado brasileiro existente</param>
    /// <param name="city">O nome da cidade relacionada ao estado brasileiro informado</param>
    /// <returns></returns>
    [HttpGet("brasilian-address")]
    public async Task<IActionResult> GetAddressAsync([FromQuery] BrazilianStateAbbreviation abbreviationState, [FromQuery] string city)
    {
        return Ok();
    }

    /// <summary>
    /// Obtém todas as cidades relacionadas ao estado brasileiro informado
    /// </summary>
    /// <param name="abbreviationState">A sigla de qualquer estado brasileiro existente</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns></returns>
    [HttpGet("brasilian-cities")]
    public async Task<IActionResult> GetCitiesAsync([FromQuery] BrazilianStateAbbreviation abbreviationState, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requisição do tipo {RequestVerb} {RequestUrl} para obter cidades para o estado de {BrasilianState}",
            Request.Method, Request.Path.Value, abbreviationState);

        var result = await _repository.GetCitiesAsync(abbreviationState.ToString(), cancellationToken);

        return Ok(new { Cities = result });
    }

    /// <summary>
    /// Obtém uma lista com todos os estados brasileiros
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns></returns>
    [HttpGet("brasilian-states")]
    public async Task<IActionResult> GetBrasilianStatesAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requisição do tipo {RequestVerb} {RequestUrl} para obter os estados do Brasil",
            Request.Method, Request.Path.Value);

        var result = await _repository.GetBrazilianStatesAsync(cancellationToken);

        return Ok(result);
    }
}
