using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentGenerator.Api.Services
{
    public static class Validations
    {
        public static bool ValidaCPF(string cpf)
        {
            // Verifica se tem o formato de cpf com pontos ou sem
            Regex regex = new(@"^\d{3}\.\d{3}\.\d{3}-\d{2}|\d{11}");
            if (!regex.IsMatch(cpf))
            {
                return false;
            }
            // Verifica se o cpf passado e uma sequencia numerica igual contendo 14 caracteres
            regex = new("/1{11}|2{11}|3{11}|4{11}|5{11}|6{11}|7{11}|8{11}|9{11}|0{11}/");
            if (regex.IsMatch(cpf))
            {
                return false;
            }
            // Verifica se tem pontos, caso sim remove
            regex = new(@"^\d{3}\.\d{3}\.\d{3}-\d{2}");
            if (regex.IsMatch(cpf))
            {
                cpf = cpf.Replace(".", "").Replace("-", "");
            }
            // Valida o primeiro digito
            int digito1 = 0;
            int multiplicador = 10;
            for (int i = 0; i < 9; i++)
            {
                int valor = int.Parse(cpf[i].ToString());
                digito1 += valor * multiplicador;
                multiplicador--;
            }
            digito1 = 11 - (digito1 %= 11);
            if (digito1 >= 10)
            {
                digito1 = 0;
            }
            // Valida o segundo digito
            int digito2 = 0;
            multiplicador = 11;
            for (int i = 0; i < 10; i++)
            {
                int valor = int.Parse(cpf[i].ToString());
                digito2 += valor * multiplicador;
                multiplicador--;
            }
            digito2 = 11 - (digito2 % 11);
            if (digito2 >= 10)
            {
                digito2 = 0;
            }
            // Verifica se o digito1 e digito2 sao correspontes com o do cpf passado
            if (int.Parse(cpf.Substring(cpf.Length - 2, 1)) == digito1 && int.Parse(cpf.Substring(cpf.Length - 1, 1)) == digito2)
            {
                return true;
            }
            return false;
        }

        public static bool ValidaRG(string rg)
        {
            // Verifica se tem o formato de rg com pontos ou sem
            Regex regex = new(@"^\d{2}\.\d{3}\.\d{3}-\d{1}|\d{9}");
            if (!regex.IsMatch(rg))
            {
                return false;
            }
            // Verifica se o rg passado e uma sequencia numerica igual contendo 14 caracteres
            regex = new("/1{9}|2{9}|3{9}|4{9}|5{9}|6{9}|7{9}|8{9}|9{9}|0{9}/");
            if (regex.IsMatch(rg))
            {
                return false;
            }
            // Verifica se tem pontos, caso sim remove
            regex = new(@"^\d{2}\.\d{3}\.\d{3}-\d{1}");
            if (regex.IsMatch(rg))
            {
                rg = rg.Replace(".", "").Replace("-", "");
            }
            // Valida��o do digito
            int digito = 0;
            int multiplicador = 2;
            for (int i = 0; i < 8; i++)
            {
                int valor = int.Parse(rg[i].ToString());
                digito += valor * multiplicador;
                multiplicador++;
            }
            digito = 11 - (digito % 11);
            // Caso o resultado da subtra��o seja 11 o d�gito sera 0
            if (digito == 11)
            {
                digito = 0;
            }
            // Verifica se o ultimo d�gito do rg passado e igual ao digito validado
            if (int.Parse(rg.Substring(rg.Length - 1, 1)) == digito)
            {
                return true;
            }
            return false;
        }

        public static bool ValidaCNPJ(string cnpj)
        {
            // Verifica se tem o formato de cnpj com pontos ou sem
            Regex regex = new(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$|\d{14}");
            if (!regex.IsMatch(cnpj))
            {
                return false;
            }
            // Verifica se o cnpj passado e uma sequencia numerica igual contendo 14 caracteres
            regex = new("/1{14}|2{14}|3{14}|4{14}|5{14}|6{14}|7{14}|8{14}|9{14}|0{14}/");
            if (regex.IsMatch(cnpj))
            {
                return false;
            }
            // Verifica se tem pontos, caso sim remove
            regex = new(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$");
            if (regex.IsMatch(cnpj))
            {
                cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
            }
            // Valida o primeiro digito
            int digito1 = 0;
            int multiplicador = 6;
            for (int i = 0; i < cnpj.Length; i++)
            {
                int valor = int.Parse(cnpj[i].ToString());
                digito1 += valor * multiplicador;
                multiplicador++;

                if (i == 3)
                    multiplicador = 2;

                if (i == 11)
                {
                    digito1 %= 11;
                    if (digito1 == 10)
                    {
                        digito1 = 0;
                    }
                    break;
                }
            }
            // Valida o segundo digito
            int digito2 = 0;
            multiplicador = 5;
            for (int i = 0; i < cnpj.Length; i++)
            {
                int valor = int.Parse(cnpj[i].ToString());
                digito2 += valor * multiplicador;
                multiplicador++;

                if (i == 4)
                    multiplicador = 2;

                if (i == 12)
                {
                    digito2 %= 11;
                    break;
                }
            }
            // Compara o resultado da validacao dos dois digitos com o numero do cnpj passado
            if (int.Parse(cnpj.Substring(cnpj.Length - 2, 1)) == digito1 && int.Parse(cnpj.Substring(cnpj.Length - 1, 1)) == digito2)
            {
                return true;
            }
            return false;
        }

        public static string RemoverAcentuacaoMinuscula(string text)
        {
            StringBuilder textReturn = new();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letra in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
                {
                    textReturn.Append(letra);
                }
            }
            return textReturn.ToString().ToLower();
        }
    }
}