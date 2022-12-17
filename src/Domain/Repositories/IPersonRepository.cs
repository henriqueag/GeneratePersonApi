namespace DocumentGeneratorApp.Domain;

public interface IPersonRepository
{
    Task<IEnumerable<string>> GetAllNames(CancellationToken cancellationToken);
}