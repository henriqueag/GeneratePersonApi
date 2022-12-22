using DocumentGeneratorApp.Domain.ValueObjects;

namespace DocumentGeneratorApp.Domain;

public record GeneratePersonParameters
{
    private readonly int? _minAge;
    private readonly int? _maxAge;
    private readonly RandomAddressConditions _conditions;

    public GeneratePersonParameters(int? minAge, int? maxAge, RandomAddressConditions conditions)
    {
        _minAge = minAge;
        _maxAge = maxAge;
        _conditions = conditions;
    }

    public int MinAge => _minAge ?? 18;
    public int MaxAge => _maxAge ?? 89;
    public RandomAddressConditions Conditions => _conditions ?? RandomAddressConditions.Default;
}