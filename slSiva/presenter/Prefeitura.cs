using System;

namespace Dominio
{
    public class Prefeitura
    {
        public decimal SQ_PREFEITURA { get; set; }
        public string NM_PREFEITURA { get; set; }
        public string NM_PREFEITO { get; set; }
        public string NM_SEC_TRIBUTACAO { get; set; }
        public string NM_CONTADOR { get; set; }
        public string NM_LOGRADOURO { get; set; }
        public string NU_NUMERO { get; set; }
        public string TX_COMPLEMENTO { get; set; }
        public string TX_CONTATO { get; set; }
        public DateTime DT_INCLUSAO { get; set; }
        public string NM_USUARIO_INCLUSAO { get; set; }
        public DateTime DT_ALTERACAO { get; set; }
        public string NM_USUARIO_ALTERACAO { get; set; }
        public decimal NU_HABITANTES { get; set; }
        public decimal QT_EXTENSAO_TERRITORIAL { get; set; }

    }
}
