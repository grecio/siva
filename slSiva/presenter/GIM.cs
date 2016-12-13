using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class GIM
    {
        public decimal CD_GUIA { get; set; }
        public string NU_REFERENCIA { get; set; }
        public string DT_RECEPCAO { get; set; }
        public string NU_INSCRICAO_ESTADUAL { get; set; }
        public string NU_CNPJ_CPF { get; set; }
        public string NM_RAZAO_SOCIAL { get; set; }
        public string NM_FANTASIA { get; set; }
        public string NM_LOGRADOURO { get; set; }
        public string NU_LOGRADOURO { get; set; }
        public string NM_COMPLEMENTO { get; set; }
        public string NU_CEP { get; set; }
        public string NM_BAIRRO { get; set; }
        public string NM_MUNICIPIO_RFB { get; set; }
        public string SG_UF_MUNICIPIO1 { get; set; }
        public decimal VL_CEST07_1 { get; set; }
        public decimal VL_CEST07_2 { get; set; }
        public decimal VL_CEST07_3 { get; set; }
        public decimal VL_CEST07_4 { get; set; }
        public decimal VL_COUT08_1 { get; set; }
        public decimal VL_COUT08_2 { get; set; }
        public decimal VL_COUT08_3 { get; set; }
        public decimal VL_COUT08_4 { get; set; }
        public decimal VL_CEXT09_1 { get; set; }
        public decimal VL_CEXT09_2 { get; set; }
        public decimal VL_CEXT09_3 { get; set; }
        public decimal VL_CEXT09_4 { get; set; }
        public decimal VL_TOTA10_1 { get; set; }
        public decimal VL_TOTA10_2 { get; set; }
        public decimal VL_TOTA10_3 { get; set; }
        public decimal VL_TOTA10_4 { get; set; }
        public decimal VL_CPES11_1 { get; set; }
        public decimal VL_CPES11_2 { get; set; }
        public decimal VL_CPES11_3 { get; set; }
        public decimal VL_CPES11_4 { get; set; }
        public decimal VL_CPOU12_1 { get; set; }
        public decimal VL_CPOU12_2 { get; set; }
        public decimal VL_CPOU12_3 { get; set; }
        public decimal VL_CPOU12_4 { get; set; }
        public decimal VL_CPEX13_1 { get; set; }
        public decimal VL_CPEX13_2 { get; set; }
        public decimal VL_CPEX13_3 { get; set; }
        public decimal VL_CPEX13_4 { get; set; }
        public decimal VL_TOTA14_1 { get; set; }
        public decimal VL_TOTA14_2 { get; set; }
        public decimal VL_TOTA14_3 { get; set; }
        public decimal VL_TOTA14_4 { get; set; }
        public decimal VL_DEBI15 { get; set; }
        public decimal VL_OUTD16 { get; set; }
        public decimal VL_ESTC17 { get; set; }
        public decimal VL_TOTA18 { get; set; }
        public decimal VL_CREI19 { get; set; }
        public decimal VL_OUTC20 { get; set; }
        public decimal VL_ESTC21 { get; set; }
        public decimal VL_SUBT22 { get; set; }
        public decimal VL_SCPA23 { get; set; }
        public decimal VL_TOTA24 { get; set; }
        public decimal VL_APUS25 { get; set; }
        public decimal VL_DEBT26 { get; set; }
        public decimal VL_APUR27 { get; set; }
        public decimal VL_APUC28 { get; set; }
        public decimal VL_NORR29 { get; set; }
        public decimal VL_NORA30 { get; set; }
        public decimal VL_SPSR31 { get; set; }
        public decimal VL_SPSA32 { get; set; }
        public decimal VL_SPER33 { get; set; }
        public decimal VL_SPEA34 { get; set; }
        public decimal VL_IMPR35 { get; set; }
        public decimal VL_IMPA36 { get; set; }
        public decimal VL_EXPR37 { get; set; }
        public decimal VL_EXPA38 { get; set; }
        public decimal VL_ANTR39 { get; set; }
        public decimal VL_ANTA40 { get; set; }
        public decimal VL_ICMR41 { get; set; }
        public decimal VL_ICMA42 { get; set; }
        public string MEST73 { get; set; }
        public decimal VL_VEST74 { get; set; }
        public string OBSERVACOES_75 { get; set; }
        
    }

    public class GIMDetalhe
    {
        public decimal CD_DETALHE { get; set; }
        public string DC_DETALHE { get; set; }
        public decimal VL_DETALHE { get; set; }
    }
}
