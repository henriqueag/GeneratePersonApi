using GeneratePersonApi.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GeneratePersonApi.Services
{
    public class ServiceDatabase : IServiceDatabase
    {
        private readonly IGravadorDeLogs _gravadorDeLogs;
        private readonly IConfiguration _configuration;

        public ServiceDatabase (IGravadorDeLogs gravadorDeLogs, IConfiguration configuration)
        {
            _gravadorDeLogs = gravadorDeLogs;
            _configuration = configuration;
        }

        public void BackupDataBase ()
        {
            try
            {
                using SqlConnection conn = new(_configuration.GetConnectionString("DefaultConnection"));
                conn.Open();
                var sql = @"BACKUP DATABASE [generatePerson] TO  DISK = N'C:\Projetos\GeneratePersonApi\Dados\Backup\generatePerson.bak' WITH NOFORMAT, INIT,  NAME = N'generatePerson-Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                using SqlCommand cmd = new(sql, conn);
                var result = cmd.ExecuteNonQuery();
                if (result == -1)
                {
                    _gravadorDeLogs.GravaLog("Backup do banco de dados realizado com sucesso", "databaseBkp.txt");
                }
            }
            catch (System.Exception ex)
            {
                _gravadorDeLogs.GravaLog(ex.ToString(), "erroGeral.txt");
            }
        }
    }
}