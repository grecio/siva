using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ResumoFinanceiroPorTipo
    {
        public string NM_RAZAO_SOCIAL { get; set; }
        public string NU_CNPJ_FILIAL { get; set; }
        public int NU_REFERENCIA { get; set; }
        public decimal? GIM { get; set; }
        public decimal? CTE { get; set; }
        public decimal? DAS { get; set; }
        public decimal? DASNSIMEI { get; set; }
    }
}
