namespace DocumentGenerator.Api.Interfaces
{
    public interface IDatabaseService
    {
        void BackupDataBase(string connectionString);
    }
}