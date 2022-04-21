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
                var path = "";//ConfigurationManager.AppSettings["PathLog"].ToString();
                //var conn = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                var config = ConfigurationManager.AppSettings;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using StreamWriter writer = new($"{path}{nomeArquivo}", true, Encoding.UTF8);
                writer.WriteLine($"\n{DateTime.Now:d} -- {mensagem}\n");
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
