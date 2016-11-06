
using Microsoft.VisualBasic;
using System;

namespace CommonFrameWork
{
    public class Formatador
    {
     
        private string _Texto;


        public Formatador(string StrTexto)
        {
            _Texto = SoNumero(StrTexto);
        }
     
        public static string SoNumero(string strTexto, string strExcessao = "")
        {

            string strAux = null;
            int intCont = 0;
            string strFrag = null;

            strAux = string.Empty;


            for (intCont = 1; intCont <= Strings.Len(strTexto); intCont++)
            {
                strFrag = Strings.Mid(strTexto, intCont, 1);


                if (strExcessao == "X")
                {

                    if (strFrag != strExcessao)
                    {

                        if (Information.IsNumeric(strFrag))
                        {
                            strAux = strAux + strFrag;

                        }


                    }
                    else
                    {
                        strAux = strAux + strFrag;

                    }


                }
                else
                {

                    if (Information.IsNumeric(strFrag))
                    {
                        strAux = strAux + strFrag;

                    }


                }


            }

            return strAux;

        }

        public static string SoLetras(string strTexto)
        {

            int vPos = 0;

            const string vComAcento = "ÀÁÂÃÄÅÇÈÉÊËÌÍÎÏÒÓÔÕÖÙÚÛÜàáâãäåçèéêëìíîïòóôõöùúûü";
            const string vSemAcento = "AAAAAACEEEEIIIIOOOOOUUUUaaaaaaceeeeiiiiooooouuuu";

            for (int i = 1; i <= Strings.Len(strTexto); i++)
            {
                vPos = Strings.InStr(1, vComAcento, Strings.Mid(strTexto, i, 1));

                if (vPos > 0)
                {
                    strTexto = Strings.Mid(vSemAcento, vPos, 1);
                }
            }

            return strTexto;
        }


        public static string ObterMesExtenso(int intMes, bool boolAbreviar = false)
        {

            string strAux = string.Empty;

            switch (intMes)
            {

                case 1:

                    strAux = (boolAbreviar ? "JAN" : "Janeiro");

                    break;
                case 2:

                    strAux = (boolAbreviar ? "FEV" : "Fevereiro");

                    break;
                case 3:

                    strAux = (boolAbreviar ? "MAR" : "Março");

                    break;
                case 4:

                    strAux = (boolAbreviar ? "ABR" : "Abril");

                    break;
                case 5:

                    strAux = (boolAbreviar ? "MAI" : "Maio");

                    break;
                case 6:

                    strAux = (boolAbreviar ? "JUN" : "Junho");

                    break;
                case 7:

                    strAux = (boolAbreviar ? "JUL" : "Julho");

                    break;
                case 8:

                    strAux = (boolAbreviar ? "AGO" : "Agosto");

                    break;
                case 9:

                    strAux = (boolAbreviar ? "SET" : "Setembro");

                    break;
                case 10:

                    strAux = (boolAbreviar ? "OUT" : "Outubro");

                    break;
                case 11:

                    strAux = (boolAbreviar ? "NOV" : "Novembro");

                    break;
                case 12:

                    strAux = (boolAbreviar ? "DEZ" : "Dezembro");

                    break;

            }

            return strAux;

        }

        public static string SemEspacos(string strTexto)
        {

            string strAux = null;
            int intCont = 0;
            string strFrag = null;

            strAux = string.Empty;


            for (intCont = 1; intCont <= Strings.Len(strTexto); intCont++)
            {
                strFrag = Strings.Mid(strTexto, intCont, 1);

                if (strFrag != " ")
                {
                    strAux = strAux + strFrag;
                }

            }

            return strAux;

        }

        public static string ExtensaoArquivo(string strArquivo)
        {

            string strAux = null;
            int lngPos = 0;

            strAux = Strings.StrReverse(strArquivo);

            lngPos = Strings.InStr(strAux, ".");

            if (lngPos == -1 || lngPos == 0)
                return strArquivo;

            strAux = Strings.Mid(strAux, 1, lngPos);

            return Strings.StrReverse(strAux);

        }

        public static string NomeArquivo(string strArquivo)
        {

            string strAux = null;
            int lngPos = 0;

            strAux = Strings.StrReverse(strArquivo);

            lngPos = Strings.InStr(strAux, "\\");

            if (lngPos == -1 || lngPos == 0)
                return strArquivo;

            strAux = Strings.Mid(strAux, 1, lngPos - 1);

            return Strings.StrReverse(strAux);

        }

        public static byte[] ConverteBinario(string str)
        {
            return System.Text.Encoding.Unicode.GetBytes(str);

        }    
          
    }
}		