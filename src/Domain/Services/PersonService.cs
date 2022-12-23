using Microsoft.Extensions.Logging;

namespace DocumentGeneratorApp.Domain;

public class PersonService : IPersonService
{
    private static readonly Random s_random = new();

    private readonly IPersonRepository _personRepository;
    private readonly IDocumentGenerator _documentGenerator;
    private readonly IPersonInformation _personInformation;
    private readonly IAddressService _addressService;
    private readonly ILogger<PersonService> _logger;

    public PersonService(IPersonRepository personRepository, IDocumentGenerator documentGenerator, IPersonInformation personInformation, IAddressService addressService, ILogger<PersonService> logger)
    {
        _personRepository = personRepository;
        _documentGenerator = documentGenerator;
        _personInformation = personInformation;
        _addressService = addressService;
        _logger = logger;
    }

    public async Task<Person> GetRandomPersonAsync(GeneratePersonParameters parameters, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Operação {OperationName} invocada para obter um cadastro aleátorio de pessoa com o payload {@Payload}",
            nameof(GetRandomPersonAsync), parameters);

        var birthDate = _personInformation.GenerateRandomBirthDate(parameters.MinAge, parameters.MaxAge);
        var age = _personInformation.GetCalculatedAge(birthDate);
        var address = await _addressService.GetAddressAsync(parameters.Conditions, cancellationToken);
        var randomName = await GetRandomNameAsync(cancellationToken);

        return new Person
        {
            Name = await GetRandomNameAsync(cancellationToken),
            Cpf = _documentGenerator.GenerateCpf(Enum.Parse<BrazilianStateAbbreviation>(address.State)),
            Rg = _documentGenerator.GenerateRg(),
            BirthDate = birthDate,
            Age = age,
            Phone = _personInformation.GenerateRandomPhone(address.Ddd),
            Email = _personInformation.GenerateRandomEmail(randomName),
            Address = address
        };
    }

    public async Task<IEnumerable<Person>> GetRandomPersonListAsync(GeneratePersonParameters parameters, CancellationToken cancellationToken, int quantity = 1)
    {
        _logger.LogDebug("Operação {OperationName} invocada para obter uma lista com {Quantity} cadastros aleátorios de pessoas com o payload {@Payload}",
            nameof(GetRandomPersonListAsync), quantity, parameters);

        var personsResult = new List<Person>(quantity);

        for (int i = 0; i < quantity; i++)
        {
            var randomPerson = await GetRandomPersonAsync(parameters, cancellationToken);
            personsResult.Add(randomPerson);
        }

        return personsResult;
    }

    private async Task<string> GetRandomNameAsync(CancellationToken cancellationToken)
    {
        var allNames = (await _personRepository.GetAllNames(cancellationToken))
            .ToArray();

        return allNames[s_random.Next(0, allNames.Length)];
    }
}