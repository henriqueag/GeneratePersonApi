using DocumentGeneratorApp.Domain;
using DocumentGeneratorApp.Infrastructure.EntityFrameworkCore;

namespace DocumentGeneratorApp.Infrastructure;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<string>> GetAllNames(CancellationToken cancellationToken)
    {
        return await _context.Set<Person>()
            .AsNoTracking()
            .Select(x => x.Name)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}