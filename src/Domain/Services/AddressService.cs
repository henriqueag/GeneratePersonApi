using DocumentGeneratorApp.Domain.Exceptions;
using DocumentGeneratorApp.Domain.ValueObjects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace DocumentGeneratorApp.Domain;

public class AddressService : IAddressService
{
    private const string _cacheKey = "abbde358-b3b0-40d6-98f4-e9fb73debe1b";

    private static readonly Random s_random = new();
    private static readonly MemoryCacheEntryOptions s_cacheOptions = new()
    {
        SlidingExpiration = TimeSpan.FromMinutes(10),
        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
    };

    private readonly IAddressRepository _repository;
    private readonly IAddressDetailService _addressDetail;
    private readonly IMemoryCache _cache;
    private readonly ILogger<AddressService> _logger;

    public AddressService(IAddressRepository repository, IAddressDetailService addressDetail, IMemoryCache cache, ILogger<AddressService> logger)
    {
        _repository = repository;
        _addressDetail = addressDetail;
        _cache = cache;
        _logger = logger;
    }

    public async Task<Address> GetAddressAsync(RandomAddressConditions randomConditions, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Operação {OperationName} invocada com payload {@Payload}", nameof(GetAddressAsync), randomConditions);

        return randomConditions switch
        {
            { TotallyRandom: true } => await GetAddressRandomAsync(cancellationToken),
            { DefinedStateAndUndefinedCity: true } => await GetAddressWithDefinedStateAndUndefinedCityAsync(randomConditions.State.Value, cancellationToken),
            { DefinedStateAndCity: true } => await GetAddressWithDefinedStateAndCityAsync(randomConditions.CityName, cancellationToken),
            { UndefinedStateAndDefinedCity: true } => throw new UserFriendlyException("state-not-defined", "O estado não pode ser nulo quando a cidade está definida"),
            _ => null
        };
    }

    public async Task<IReadOnlyCollection<BrazilianState>> GetBrazilianStatesAsync(CancellationToken cancellationToken)
    {
        if(_cache.TryGetValue<IReadOnlyCollection<BrazilianState>>(_cacheKey, out var fromCache))
        {
            _logger.LogDebug("A lista de estados brasileiros foi recuperada do cache");

            return fromCache;
        }
        
        var fromDatabase = await _repository.GetBrazilianStatesAsync(cancellationToken);
        _cache.Set(_cacheKey, fromDatabase, s_cacheOptions);

        _logger.LogDebug("A lista de estados brasileiros foi recuperada do banco de dados e adicionada no cache");

        return fromDatabase;
    }

    private async Task<Address> GetAddressRandomAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("Operação {OperationName} invocada para obter um endereço totalmente aleátorio", nameof(GetAddressRandomAsync));

        var stateToArray = Enum.GetValues<BrazilianStateAbbreviation>();
        var randomState = stateToArray[s_random.Next(0, stateToArray.Length)];

        var cities = await _repository.GetCitiesAsync(randomState.ToString(), cancellationToken);
        var randomCity = cities.ElementAt(s_random.Next(0, cities.Count));

        var addressResult = Address.Default;
        while (!addressResult.IsValidAddress())
        {
            addressResult = await GetAddressByRandomCepAsync(randomCity, cancellationToken);
        }

        return addressResult;
    }

    private async Task<Address> GetAddressWithDefinedStateAndUndefinedCityAsync(BrazilianStateAbbreviation state, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Operação {OperationName} invocada para obter um endereço do estado de {State}", 
            nameof(GetAddressWithDefinedStateAndUndefinedCityAsync), state);

        var cities = await _repository.GetCitiesAsync(state.ToString(), cancellationToken);
        var randomCity = cities.ElementAt(s_random.Next(0, cities.Count));

        var addressResult = Address.Default;
        while (!addressResult.IsValidAddress())
        {
            addressResult = await GetAddressByRandomCepAsync(randomCity, cancellationToken);
        }

        return addressResult;
    }

    private async Task<Address> GetAddressWithDefinedStateAndCityAsync(string cityName, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Operação {OperationName} invocada para obter um endereço da cidade {CityName}", 
            nameof(GetAddressWithDefinedStateAndCityAsync), cityName);

        var addressResult = Address.Default;
        while (!addressResult.IsValidAddress())
        {
            addressResult = await GetAddressByRandomCepAsync(cityName, cancellationToken);
        }

        return addressResult;
    }

    private async Task<Address> GetAddressByRandomCepAsync(string cityName, CancellationToken cancellationToken)
    {
        var ceps = await _repository.GetCepsByCityAsync(cityName, cancellationToken);
        var randomCep = ceps.ElementAt(s_random.Next(0, ceps.Count));

        var result = await _addressDetail.GetAddressByCepAsync(randomCep, cancellationToken);
        
        return result;
    }
}