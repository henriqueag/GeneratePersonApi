using DocumentGeneratorApp.Domain;
using DocumentGeneratorApp.Infrastructure.EntityFrameworkCore;

namespace DocumentGeneratorApp.Infrastructure;

public class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _context;

    public AddressRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<string>> GetCitiesAsync(string brazilianState, CancellationToken cancellationToken)
    {
        FormattableString sql = $"SELECT DISTINCT [City], [State] FROM [Address] WHERE [State] = {brazilianState}";

        return await _context.Set<Address>()
            .FromSql(sql)
            .Select(x => x.City)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<BrazilianStates>> GetBrazilianStatesAsync(CancellationToken cancellationToken)
    {
        const string sql = "SELECT [City], [State] FROM [CapitalCityAndState]";

        return await _context.Set<Address>()
            .FromSqlRaw(sql)
            .Select(x => new BrazilianStates(x.City, x.State))
            .ToListAsync(cancellationToken);
    }
}
