using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Referencia
    {
        public class GIM
        {
            public decimal CD_GUIA { get; set; }
            public string NU_REFERENCIA { get; set; }
            public string DT_RECEPCAO { get; set; }
        }

        public class InformativoFiscal
        {
            public decimal CD_INFORMATIVO { get; set; }
            public string CD_INFORMATICO_REP { get; set; }
            public string NU_REFERENCIA { get; set; }
            public string DT_ENVIO { get; set; }
        }
    }
}
