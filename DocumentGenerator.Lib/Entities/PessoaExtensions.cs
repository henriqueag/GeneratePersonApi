using System.Collections.Generic;

namespace DocumentGenerator.Lib.Entities
{
    public static class PessoaExtensions
    {
        public static PessoaApi ToApi(this Pessoa pessoa)
        {
            EnderecoApi enderecoApi = new (pessoa.Endereco);
            return new PessoaApi(pessoa.Nome, pessoa.Cpf, pessoa.Rg, pessoa.DataNasc, pessoa.Idade, pessoa.Telefone, pessoa.Email, enderecoApi);
        }

        public static List<PessoaApi> ToApi(this IEnumerable<Pessoa> pessoas)
        {
            var list = new List<PessoaApi>();
            foreach (var obj in pessoas)
            {
                list.Add(ToApi(obj));
            }
            return list;
        }
    }
}