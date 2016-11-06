using Microsoft.VisualBasic;
using System;

namespace CommonFrameWork
{
    public class Validador
    {


        private static string[] CPF = {
        "11111111111",
        "22222222222",
        "33333333333",
        "44444444444",
        "55555555555",
        "66666666666",
        "77777777777",
        "88888888888",
        "99999999999"

    };
        public const string REGULAR_EXPRESSION_EMAIL = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        public const string REGULAR_EXPRESSION_CEP = "^[0-9]{5}\\-[0-9]{3}$";
        public const string REGULAR_EXPRESSION_PROCESSO = "^[0-9]{8}\\/[0-9]{4}$";
        public const string REGULAR_EXPRESSION_DATA = "(((0[1-9]|[12][0-9]|3[01])([/])(0[13578]|10|12)([/])(\\d{4}))|(([0][1-9]|[12][0-9]|30)([/])(0[469]|11)([/])(\\d{4}))|((0[1-9]|1[0-9]|2[0-8])([/])(02)([/])(\\d{4}))|((29)(\\.|-|\\/)(02)([/])([02468][048]00))|((29)([/])(02)([/])([13579][26]00))|((29)([/])(02)([/])([0-9][0-9][0][48]))|((29)([/])(02)([/])([0-9][0-9][2468][048]))|((29)([/])(02)([/])([0-9][0-9][13579][26])))";
        public const string REGULAR_EXPRESSION_CONTA = "^[0-9]+-[0-9xX]$";

        public const string REGULAR_EXPRESSION_ELEMENTODESPES91 = "^[0-9]{2}91[0-9]{2}$";

        public static object ChecarNulo(object vTexto, bool Numerico = false)
        {
            object functionReturnValue = null;


            if (((vTexto == null) || object.ReferenceEquals(vTexto, DBNull.Value)))
            {
                if (Numerico)
                {
                    functionReturnValue = 0;
                }
                else
                {
                    functionReturnValue = "";
                }


            }
            else
            {
                functionReturnValue = vTexto;

            }
            return functionReturnValue;

        }

        public static string ValidarValor(string Valor)
        {
            if (!Information.IsNumeric(Valor.Trim()))
            {
                return "0";
            }
            else
            {
                return Valor;
            }

        }



        public static void Validar(bool blnCondicao, string strMensagem)
        {

            if (!blnCondicao)
            {
                throw new ApplicationException(strMensagem);

            }

        }

        public static bool ValidarElemento91(string strElementoDespesa)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(strElementoDespesa, REGULAR_EXPRESSION_ELEMENTODESPES91);

        }

        public static bool ValidarEMail(string strEMail)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(strEMail, REGULAR_EXPRESSION_EMAIL);

        }

        public static bool ValidarConta(string conta)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(conta, REGULAR_EXPRESSION_CONTA);

        }

        public static bool ValidarCEP(string strCEP)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(strCEP, REGULAR_EXPRESSION_CEP);

        }

        public static bool ValidarData(string strData)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(strData, REGULAR_EXPRESSION_DATA);

        }

        public static bool ValidarProcesso(string strProcesso)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(strProcesso, REGULAR_EXPRESSION_PROCESSO);

        }

        public static bool ValidaCPF(string CPF)
        {

            int i = 0;
            int x = 0;
            int n1 = 0;
            int n2 = 0;

            CPF = CPF.Trim();


            for (i = 0; i <= CPF.Length - 1; i++)
            {

                if (CPF.Length != 11 || CPF[i].Equals(CPF))
                {
                    return false;

                }

            }


            for (x = 0; x <= 1; x++)
            {
                n1 = 0;


                for (i = 0; i <= 8 + x; i++)
                {
                    n1 = n1 + Convert.ToInt32(Conversion.Val(CPF.Substring(i, 1)) * (10 + x - i));
                }

                n2 = 11 - (n1 - (Conversion.Int(n1 / 11) * 11));

                if (n2 == 10 | n2 == 11)
                    n2 = 0;


                if (n2 != Conversion.Val(CPF.Substring(9 + x, 1)))
                {
                    return false;

                }
            }

            return true;

        }

    }
}
