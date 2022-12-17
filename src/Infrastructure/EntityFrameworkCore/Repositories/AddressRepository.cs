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

    public async Task<IEnumerable<string>> GetCities(BrazilianStateAbbreviation state, CancellationToken cancellationToken)
    {
        return await _context.Set<Address>()
            .AsNoTracking()
            .Where(x => x.State.Equals(state.ToString()))
            .Select(x => x.City)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<BrazilianStates>> GetBrazilianStates(CancellationToken cancellationToken)
    {
        return await _context.Set<Address>()
            .AsNoTracking()
            .DistinctBy(x => x.State)
            .Select(x => new BrazilianStates(x.City, x.State))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
