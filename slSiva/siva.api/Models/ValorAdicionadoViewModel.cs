using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace siva.api.Models
{
    public class ValorAdicionadoViewModel
    {

        private readonly BLL.BLLMunicipio bpMunicipio;

        public ValorAdicionadoViewModel()
        {
            bpMunicipio = new BLL.BLLMunicipio();
        }

        public ValorAdicionadoCabecalho Cabecalho { get; set; }

        public ValorAdicionadoDetalhamento Detalhamento { get; set; }

        public string SituacaoProcesso
        {
            get
            {
                if (Cabecalho.ST_PROCESSO == 0)
                    return "Em execução";
                else if (Cabecalho.ST_PROCESSO == 1)
                    return "Concluído com sucesso";
                else
                    return "Finalizado com erro";
                
            }
        }

        public string CabecalhoParametros
        {
            get
            {
                var builder = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(Cabecalho.DC_PARAMETROS))
                {
                    var parametrosList = Cabecalho.DC_PARAMETROS.Split('|');

                    decimal codigo = 0;

                    foreach (var item in parametrosList)
                    {
                        var keyList = item.Split(':');

                        if (keyList.Length > 0)
                        {
                            if (keyList[0].ToLower().Contains("pcdmunicipio"))
                            {
                                decimal.TryParse(keyList[1], out codigo);

                                if (codigo > 0)
                                {
                                    var municipio = bpMunicipio.RetornaMunicipioPorCodigo(codigo);

                                    if (municipio != null)
                                        keyList[1] = municipio.NM_MUNICIPIO_RFB;

                                    builder.AppendLine(string.Format("Município : {0}", keyList[1]));
                                }
                            }
                            else if (keyList[0].ToLower().Contains("panobase"))
                            {
                                builder.AppendLine(string.Format("Ano : {0}", keyList[1]));
                            }
                            else if (keyList[0].ToLower().Contains("ptpcalculo"))
                            {
                                builder.AppendLine(string.Format("Tipo do Cálculo: {0}", keyList[1].ToLower() == "p" ? "Provisório" : "Definitivo"));
                            }
                        }
                    }
                }

                return builder.ToString();
            }
        }
    }
}