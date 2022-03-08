using System;
using GeneratePersonApi.Entities;

namespace GeneratePersonApi.Services
{
    public static class GeradorDeDados
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

        public static string GeraCpfValidado(bool gerarComPonto = false)
        {
            Random random = new Random();
            string cpf = string.Empty;
            while (true)
            {
                while (true)
                {
                    cpf = Math.Pow(random.NextDouble(), 2).ToString().Substring(2, 11);
                    if (cpf.Length == 11)
                        break;
                }
                if (Validations.ValidaCPF(cpf))
                {
                    break;
                }
            }
            if (gerarComPonto)
            {
                cpf = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                return cpf;
            }
            return cpf;
        }

        public static string GeraRgValido(bool gerarComPonto = false)
        {
            Random random = new Random();
            string rg = string.Empty;
            while (true)
            {
                while (true)
                {
                    rg = Math.Pow(random.NextDouble(), 2).ToString().Substring(2, 9);
                    if (rg.Length == 9)
                        break;
                }
                if (Validations.ValidaRG(rg))
                {
                    break;
                }
            }
            if (gerarComPonto)
            {
                rg = rg.Insert(2, ".").Insert(6, ".").Insert(10, "-");
                return rg;
            }
            return rg;
        }

        public static DateTime GerarDataPorIdade(int idade)
        {
            DateTime dataNascimento;
            Random random = new();
            int mes;

            while (true)
            {
                int temp = idade;
                var anoNascimento = DateTime.Now.Year - idade;

                if (DateTime.Now.Month == 12)
                    mes = random.Next(1, DateTime.Now.Month);
                else
                    mes = random.Next(1, DateTime.Now.Month + 1);

                int dia = random.Next(1, DateTime.DaysInMonth(anoNascimento, mes));
                dataNascimento = new DateTime(anoNascimento, mes, dia);

                if (dataNascimento.Day > DateTime.Now.Day && dataNascimento.Month == DateTime.Now.Month)
                    temp--;
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
            Random random = new Random();
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