using System;
using Xunit;
using DocumentGenerator.Lib;
using DocumentGenerator.Lib.Interfaces;
using DocumentGenerator.Lib.Services;

namespace DocumentGenerator.Test
{
    public class UnitTeste_01
    {
        [Fact]
        public void ReadConnectionStringAndPathLog()
        {
            ILogRegisterService logRegisterService = new LogRegisterService();
            IDatabaseService databaseService = new DatabaseService(logRegisterService);

            logRegisterService.GravaLog("Teste gravação", "arquivoTeste");
            databaseService.BackupDataBase();
        }
    }
}
