using GeneratePersonApi.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace GeneratePersonApi.Services
{
    public class GravadorDeLogs : IGravadorDeLogs
    {
        private readonly IConfiguration _configuration;

        public GravadorDeLogs (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void GravaLog (string mensagem, string nomeArquivo)
        {
            try
            {
                var path = _configuration.GetSection("Logs").GetSection("DefaultPath").Value;
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
