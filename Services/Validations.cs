using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentGenerator.Services
{
    public static class Validations
    {
        public static bool ValidaCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            switch (cpf)
            {
                case "11111111111": return false;
                case "22222222222": return false;
                case "33333333333": return false;
                case "44444444444": return false;
                case "55555555555": return false;
                case "66666666666": return false;
                case "77777777777": return false;
                case "88888888888": return false;
                case "99999999999": return false;
            }
            if (cpf.Length != 11)
            {
                return false;
            }

            int soma1 = 0;
            int cont = 10;
            for (int i = 0; i < cpf.Length; i++)
            {
                soma1 += Convert.ToInt32(cpf.Substring(i, 1)) * cont;
                cont--;
                if (cont == 1) break;
            }
            int digitoVerificador1 = 11 - (soma1 % 11) >= 10 ? 0 : 11 - (soma1 % 11);

            int soma2 = 0;
            cont = 11;
            for (int i = 0; i < cpf.Length; i++)
            {
                soma2 += Convert.ToInt32(cpf.Substring(i, 1)) * cont;
                cont--;
                if (cont == 1) break;
            }
            int digitoVerificador2 = 11 - (soma2 % 11) >= 10 ? 0 : 11 - (soma2 % 11);

            return string.Concat(digitoVerificador1, digitoVerificador2).Equals(cpf.Substring(9, 2));
        }

        public static bool ValidaRG(string rg)
        {
            rg = rg.Replace(".", "").Replace("-", "");

            var regex = new Regex("[0-9]{9}");
            if (!regex.IsMatch(rg))
                return false;

            switch (rg)
            {
                case "111111111": return false;
                case "222222222": return false;
                case "333333333": return false;
                case "444444444": return false;
                case "555555555": return false;
                case "666666666": return false;
                case "777777777": return false;
                case "888888888": return false;
                case "999999999": return false;
            }

            int soma = 0;
            int cont = 2;
            for (var i = 0; i < rg.Length; i++)
            {
                int.TryParse(rg.Substring(i, 1), out int numero);
                if (cont != 10)
                {
                    soma += numero * cont;
                    cont++;
                }
                else
                {
                    cont = 100;
                    soma += numero * cont;
                }
            }
            if (soma % 11 == 0)
                return true;

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