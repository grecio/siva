using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siva.api.Models
{
    public class ResumoFinanceiroPorTipoViewModel
    {
        public List<ResumoFinanceiroPorTipo> ResumoList { get; set; }
        public int AnoInicial { get; set; }
        public int AnoFinal { get; set; }
        public long? CodigoMunicipio { get; set; }
    }
}