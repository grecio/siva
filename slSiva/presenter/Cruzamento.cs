using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CruzamentoCabecalho
    {
        public int NU_PROCESSO { get; set; }
        public string CD_PROCESSO { get; set; }
        public int ST_PROCESSO { get; set; }
        public DateTime DT_INICIO_EXECUCAO { get; set; }
        public DateTime DT_FINAL_EXECUCAO { get; set; }
        public string TX_ERRO { get; set; }
        public string DC_PARAMETROS { get; set; }
        public decimal CD_CRUZAMENTO { get; set; }        
    }

    public class CruzamentoDetalhamento
    {
        public string NU_CNPJ_CPF { get; set; }
        public string CD_CRUZAMENTO { get; set; }
        public string NU_REFERENCIA { get; set; }
        public string NU_INSCRICAO_ESTADUAL { get; set; }
        public string DC_CRUZAMENTO { get; set; }
        public decimal VL_APURADO { get; set; }
        public decimal VL_REFERENCIA { get; set; }
        public decimal VL_DIFERENCA { get; set; }
        public decimal VL_EXPECTATIVA_RECEITA { get; set; }
        public long NU_PROCESSO { get; set; }
        public DateTime DT_ATUALIZACAO { get; set; }
        public string NM_USUARIO_ATUALIZACAO { get; set; }
        public decimal CD_MUNICIPIO { get; set; }

    }

    public class CruzamentoTipo
    {
        public decimal CD_CRUZAMENTO { get; set; }
        public string DC_CRUZAMENTO { get; set; }
        public string FG_CRITICAR { get; set; }
        public string FG_ISENCAO { get; set; }
    }
}
