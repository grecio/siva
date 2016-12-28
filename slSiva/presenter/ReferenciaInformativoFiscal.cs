using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ReferenciaInformativoFiscal
    {
        public decimal CD_INFORMATIVO { get; set; }
        public string NU_REFERENCIA { get; set; }
        public DateTime DT_ENVIO { get; set; }
        public string NU_INSCRICAO_ESTADUAL { get; set; }
        public string NU_CNPJ_CPF { get; set; }
        public string NM_RAZAO_SOCIAL { get; set; }
        public string NM_FANTASIA { get; set; }

    }
}
