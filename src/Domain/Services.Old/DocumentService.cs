using System;
using DocumentGeneratorApp.Api.Entities;
using DocumentGeneratorApp.Api.Interfaces;

namespace DocumentGeneratorApp.Api.Services
{
    public class DocumentService : IDocumentService
    {
        public int CalculaIdade(DateTime dataNascimento)
        {
            var span = DateTime.Now.Subtract(dataNascimento);
            var dias = span.TotalDays;
            double idade = dias / 365.2596;

            if (dataNascimento.Month == DateTime.Now.Month && dataNascimento.Day > DateTime.Now.Day)
                idade--;

            return (int)idade;
        }

        public string GeraCNPJValido()
        {
            Random random = new();
            string cnpj = string.Empty;
            while (true)
            {
                for (int i = 0; i < 10; i++)
                {
                    cnpj += random.Next(0, 9);
                    if (cnpj.Length == 8)
                    {
                        cnpj += "0001";
                    }
                }
                if (!Validations.ValidaCNPJ(cnpj))
                    cnpj = "";
                else
                    break;
            }
            return cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
        }

        public string GeraCPFValido(string estadoBR_sigla, bool gerarComPonto = true)
        {
            // valor de retorno
            string cpf_retorno = string.Empty;

            // Funcao que gera o cpf. O parametro e definido nas condicoes abaixo.
            string FunctionTemp(int digitoDoEstado)
            {
                Random random = new();
                string cpf = string.Empty;
                while (true)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        cpf += random.Next(0, 9);
                        if (cpf.Length == 8)
                        {
                            cpf += digitoDoEstado;
                        }
                    }
                    if (!Validations.ValidaCPF(cpf))
                        cpf = "";
                    else
                        break;
                }
                return cpf;
            }
            // Condições para definir o estado do cpf a ser gerado.
            if (estadoBR_sigla.Equals("RS"))
            {
                cpf_retorno = FunctionTemp(0);
            }
            if (estadoBR_sigla.Equals("DF") || estadoBR_sigla.Equals("GO") || estadoBR_sigla.Equals("MT") || estadoBR_sigla.Equals("MS") || estadoBR_sigla.Equals("TO"))
            {
                cpf_retorno = FunctionTemp(1);
            }
            if (estadoBR_sigla.Equals("AM") || estadoBR_sigla.Equals("PA") || estadoBR_sigla.Equals("RR") || estadoBR_sigla.Equals("AP") || estadoBR_sigla.Equals("AC") || estadoBR_sigla.Equals("RO"))
            {
                cpf_retorno = FunctionTemp(2);
            }
            if (estadoBR_sigla.Equals("CE") || estadoBR_sigla.Equals("MA") || estadoBR_sigla.Equals("PI"))
            {
                cpf_retorno = FunctionTemp(3);
            }
            if (estadoBR_sigla.Equals("PB") || estadoBR_sigla.Equals("PE") || estadoBR_sigla.Equals("AL") || estadoBR_sigla.Equals("RN"))
            {
                cpf_retorno = FunctionTemp(4);
            }
            if (estadoBR_sigla.Equals("BA") || estadoBR_sigla.Equals("SE"))
            {
                cpf_retorno = FunctionTemp(5);
            }
            if (estadoBR_sigla.Equals("MG"))
            {
                cpf_retorno = FunctionTemp(6);
            }
            if (estadoBR_sigla.Equals("RJ") || estadoBR_sigla.Equals("ES)"))
            {
                cpf_retorno = FunctionTemp(7);
            }
            if (estadoBR_sigla.Equals("SP"))
            {
                cpf_retorno = FunctionTemp(8);
            }
            if (estadoBR_sigla.Equals("PR") || estadoBR_sigla.Equals("SC"))
            {
                cpf_retorno = FunctionTemp(9);
            }

            // Defini se vai ter ponto ou nao
            if (gerarComPonto)
                return cpf_retorno.Insert(3, ".").Insert(7, ".").Insert(11, "-");

            return cpf_retorno;
        }

        public string GeraRGValido(bool gerarComPonto = true)
        {
            Random random = new();
            string rg = string.Empty;
            while (true)
            {
                for (int i = 0; i < 9; i++)
                {
                    rg += random.Next(0, 9);
                }
                if (!Validations.ValidaRG(rg))
                    rg = "";
                else
                    break;
            }
            // Insere a mascara do RG
            if (gerarComPonto)
                return rg.Insert(2, ".").Insert(6, ".").Insert(10, "-");

            return rg;
        }

        public DateTime GerarDataPorIdade(int idade)
        {
            DateTime dataNascimento;
            Random random = new();
            int mes;

            while (true)
            {
                var anoNascimento = DateTime.Now.Year - idade;

                if (DateTime.Now.Month == 12)
                    mes = random.Next(1, DateTime.Now.Month);
                else
                    mes = random.Next(1, DateTime.Now.Month + 1);

                int dia = random.Next(1, DateTime.DaysInMonth(anoNascimento, mes));
                dataNascimento = new DateTime(anoNascimento, mes, dia);

                if (dataNascimento.Day > DateTime.Now.Day && dataNascimento.Month == DateTime.Now.Month)
                    idade--;
                else
                    break;
            }
            return dataNascimento;
        }

        public DateTime GerarIdadeAleatoria()
        {
            Random random = new();
            var inicial = DateTime.Now.Year - 65;
            var final = DateTime.Now.Year - 18;

            var mes = random.Next(1, 12);
            var dia = random.Next(1, DateTime.DaysInMonth(DateTime.Now.Year, mes));
            var ano = random.Next(inicial, final);

            return new DateTime(ano, mes, dia);
        }

        public string GeraTelefoneAleatorio(Endereco endereco)
        {
            if (endereco is null)
            {
                throw new ArgumentNullException(nameof(endereco));
            }
            int[] inicioNumero = new int[] { 999, 998, 988, 989, 987, 997 };
            Random random = new();
            string telefone = $"{endereco.DDD} {inicioNumero[random.Next(0, inicioNumero.Length)]}{random.Next(100000, 999999)}";
            telefone = telefone.Insert(0, "(").Insert(3, ")").Insert(10, "-");
            return telefone;
        }

        public string GeraEmailAleatorio(string nome)
        {
            string[] sufixoEmail = new string[] { "gmail", "yahoo", "hotmail", "outlook", "mail" };
            Random random = new();
            int index = random.Next(0, sufixoEmail.Length);
            nome = nome.Replace(" ", "").ToLower();
            nome = Validations.RemoverAcentuacaoMinuscula(nome);
            return $"{nome}@{sufixoEmail[index]}.com";
        }
    }
}