using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ValorAdicionadoCabecalho
    {
        public int NU_PROCESSO { get; set; }
        public string CD_PROCESSO { get; set; }
        public int ST_PROCESSO { get; set; }
        public DateTime DT_INICIO_EXECUCAO { get; set; }
        public DateTime DT_FINAL_EXECUCAO { get; set; }
        public string TX_ERRO { get; set; }
        public string DC_PARAMETROS { get; set; }
    }


    public class ValorAdicionadoDetalhamento
    {
        public string TP_INFORMACAO { get; set; }
        public decimal CD_MUNICIPIO { get; set; }        
        public string NU_CNPJ { get; set; }
        public string NU_IE { get; set; }
        public string NM_RAZAO_SOCIAL { get; set; }
        public string TP_CALCULO { get; set; }
        public int NU_PROCESSO { get; set; }
        public int NU_REFERENCIA { get; set; }
        public decimal? VL_BASE_CALCULO { get; set; }
        public decimal? VL_ICMS { get; set; }
        public decimal? VL_VAL_ADIC { get; set; }
        public string NM_MUNICIPIO { get; set; }
    }
}
