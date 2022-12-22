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

    public async Task<IReadOnlyCollection<BrazilianState>> GetBrazilianStatesAsync(CancellationToken cancellationToken)
    {
        const string sql = "SELECT [City], [State] FROM [CapitalAndState]";

        return await _context.Set<Address>()
            .FromSqlRaw(sql)
            .Select(x => new BrazilianState(x.City, x.State))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<string>> GetCepsByCityAsync(string city, CancellationToken cancellationToken)
    {
        return await _context.Set<Address>()
            .Where(x => x.City.Equals(city))
            .Select(x => x.Cep)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
