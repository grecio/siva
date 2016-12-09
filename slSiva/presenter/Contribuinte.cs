using System;

namespace Dominio
{
    public class Contribuinte
    {

        public decimal SQ_CONTRIBUINTE { get; set; }
        public string NU_INSCRICAO_ESTADUAL { get; set; }
        public string NU_CNPJ_CPF { get; set; }
        public string NM_RAZAO_SOCIAL { get; set; }
        public string NM_FANTASIA { get; set; }
        public string CD_MUNICIPIO { get; set; }
        public string NM_LOGRADOURO { get; set; }
        public string NU_LOGRADOURO { get; set; }
        public string NM_COMPLEMENTO { get; set; }
        public string NU_CEP { get; set; }
        public string NM_BAIRRO { get; set; }
        public string NU_TELEFONE { get; set; }
        public string NM_EMAIL_COMERCIAL { get; set; }
        public string NM_ORGAO { get; set; }
        public string NU_CNAE_FISCAL_PRIMARIO { get; set; }
        public string TP_REGIME_PAGAMENTO { get; set; }
        public string ST_SITUACAO_CADASTRAL { get; set; }
        public decimal CD_CONTRIBUINTE { get; set; }
        public DateTime? DT_INICIO_ATIVIDADE { get; set; }
        public string NU_INSCRICAO_MUNICIPAL { get; set; }

    }
}
