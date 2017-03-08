using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dominio
{
    public class ResumoFinanceiro
    {
        public string NM_RAZAO_SOCIAL { get; set; }
        public string NU_CNPJ_FILIAL { get; set; }
        public string TP_RECEITA { get; set; }
        public List<dynamic> ANOS_RECEITA { get; set; } = new List<dynamic>();

        public string Data
        {
            get
            {

                var dados = new ArrayList();

                foreach (var item in ANOS_RECEITA)
                {
                    dados.Add(new
                    {
                        ano = item.Key,
                        Value = item.Value != null ? Convert.ToDecimal(item.Value) : 0
                    });
                }

                return JsonConvert.SerializeObject(dados.ToArray());
            }
        }
    }
}
