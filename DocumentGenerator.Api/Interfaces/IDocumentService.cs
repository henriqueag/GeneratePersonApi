using DocumentGenerator.Api.Entities;
using System;

namespace DocumentGenerator.Api.Interfaces
{
    public interface IDocumentService
    {
        int CalculaIdade(DateTime dataNascimento);
        string GeraCNPJValido();
        string GeraCPFValido(string estadoBR_sigla, bool gerarComPonto = true);
        string GeraEmailAleatorio(string nome);
        DateTime GerarDataPorIdade(int idade);
        string GeraRGValido(bool gerarComPonto = true);
        DateTime GerarIdadeAleatoria();
        string GeraTelefoneAleatorio(Endereco endereco);
    }
}