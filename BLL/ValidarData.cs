using System;
using System.Globalization;
using System.Text;

namespace BLL
{
    public class ValidarData
    {
        public static void Ver_Data(string data)//Validando a data de nascimento do formulário 
        {
            DateTime Data = Convert.ToDateTime(data);
        }

        public static void Ver_Hora(string hora)
        {
            DateTime Hora = Convert.ToDateTime(hora);
        }

        public static string RemoverAcentos(string texto)
        {
            var normalized = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = Char.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark) 
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormD);
        }
    }
}
