using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ResumoFinanceiro
    {
        public string NU_CNPJ_FILIAL { get; set; }
        public string TP_RECEITA  { get; set; }
        public List<dynamic> ANOS_RECEITA { get; set; } = new List<dynamic>();

    }
}
