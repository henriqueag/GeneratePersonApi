using DocumentGenerator.Lib.Interfaces;
using System.Configuration;
using System;
using System.IO;
using System.Text;

namespace DocumentGenerator.Lib.Services
{
    public class LogRegisterService : ILogRegisterService
    {
        public LogRegisterService()
        {
        }

        public void GravaLog(string mensagem, string nomeArquivo)
        {
            try
            {
                if (!Directory.Exists(Properties.Resources.PathLog))
                {
                    Directory.CreateDirectory(Properties.Resources.PathLog);
                }
                using StreamWriter writer = new($"{Properties.Resources.PathLog}{nomeArquivo}", true, Encoding.UTF8);
                writer.WriteLine($"\n{DateTime.Now:d} -- {mensagem}\n");
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
