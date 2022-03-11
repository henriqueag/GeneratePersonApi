namespace DocumentGenerator.Interfaces
{
    public interface IGravadorDeLogs
    {
        void GravaLog (string mensagem, string nomeArquivo);
    }
}