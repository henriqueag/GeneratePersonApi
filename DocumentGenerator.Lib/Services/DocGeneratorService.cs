using System;
using DocumentGenerator.Lib.Entities;
using DocumentGenerator.Lib.Entities.Enum;

namespace DocumentGenerator.Lib.Services
{
    public static class DocGeneratorService
    {
        public static int CalculaIdade(DateTime dataNascimento)
        {
            var span = DateTime.Now.Subtract(dataNascimento);
            var dias = span.TotalDays;
            double idade = dias / 365.2596;

            if (dataNascimento.Month == DateTime.Now.Month && dataNascimento.Day > DateTime.Now.Day)
                idade--;

            return (int)idade;
        }

        public static string GeraCNPJValido()
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

        public static string GeraCPFValido(EstadosBR estado, bool gerarComPonto = true)
        {
            // valor de retorno
            string cpf_retorno = string.Empty;

            // Fun��o que gera o cpf. O parametro � definido nas condi��es abaixo.
            static string FunctionTemp(int digitoDoEstado)
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
            if (estado == EstadosBR.RS)
            {
                cpf_retorno = FunctionTemp(0);
            }
            if (estado == EstadosBR.DF | estado == EstadosBR.GO | estado == EstadosBR.MT | estado == EstadosBR.MS | estado == EstadosBR.TO)
            {
                cpf_retorno = FunctionTemp(1);
            }
            if (estado == EstadosBR.AM | estado == EstadosBR.PA | estado == EstadosBR.RR | estado == EstadosBR.AP | estado == EstadosBR.AC | estado == EstadosBR.RO)
            {
                cpf_retorno = FunctionTemp(2);
            }
            if (estado == EstadosBR.CE | estado == EstadosBR.MA | estado == EstadosBR.PI)
            {
                cpf_retorno = FunctionTemp(3);
            }
            if (estado == EstadosBR.PB | estado == EstadosBR.PE | estado == EstadosBR.AL | estado == EstadosBR.RN)
            {
                cpf_retorno = FunctionTemp(4);
            }
            if (estado == EstadosBR.BA | estado == EstadosBR.SE)
            {
                cpf_retorno = FunctionTemp(5);
            }
            if (estado == EstadosBR.MG)
            {
                cpf_retorno = FunctionTemp(6);
            }
            if (estado == EstadosBR.RJ | estado == EstadosBR.ES)
            {
                cpf_retorno = FunctionTemp(7);
            }
            if (estado == EstadosBR.SP)
            {
                cpf_retorno = FunctionTemp(8);
            }
            if (estado == EstadosBR.PR | estado == EstadosBR.SC)
            {
                cpf_retorno = FunctionTemp(9);
            }

            // Defini se vai ter ponto ou n�o
            if (gerarComPonto)
                return cpf_retorno.Insert(3, ".").Insert(7, ".").Insert(11, "-");

            return cpf_retorno;
        }

        public static string GeraRGValido(bool gerarComPonto = true)
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

        public static DateTime GerarDataPorIdade(int idade)
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

        public static DateTime GerarIdadeAleatoria()
        {
            Random random = new();
            var inicial = DateTime.Now.Year - 65;
            var final = DateTime.Now.Year - 18;

            var mes = random.Next(1, 12);
            var dia = random.Next(1, DateTime.DaysInMonth(DateTime.Now.Year, mes));
            var ano = random.Next(inicial, final);

            return new DateTime(ano, mes, dia);
        }

        public static string GeraTelefoneAleatorio(Endereco endereco)
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

        public static string GeraEmailAleatorio(string nome)
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