using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace siva.api.Models
{
    public class CruzamentoViewModel
    {
        private readonly BLL.BLLMunicipio bpMunicipio;

        public CruzamentoViewModel()
        {
            bpMunicipio = new BLL.BLLMunicipio();
        }

        public CruzamentoCabecalho Cabecalho { get; set; }
        public CruzamentoDetalhamento Detalhamento { get; set; }

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
                            if (keyList[0].ToLower().Contains("municipio"))
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
                            else if (keyList[0].ToLower().Contains("anoinicial"))
                            {
                                builder.AppendLine(string.Format("Ano Inicial: {0}", keyList[1]));
                            }
                            else if (keyList[0].ToLower().Contains("anofinal"))
                            {
                                builder.AppendLine(string.Format("Ano Final: {0}", keyList[1]));
                            }
                        }                        
                    }
                }

                return builder.ToString();
            }
        }
    }
}