using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siva.api.Models
{
    public class GIMViewModel
    {
        public GIM GIM { get; set; }
        public List<GIMDetalhe> GIMDetalhe { get; set; }        
    
        public decimal RetornaValorDetalhamentoPorCodigo(decimal codigo)
        {
            var gimDetalhe = GIMDetalhe.SingleOrDefault(item => item.CD_DETALHE == codigo);

            if (gimDetalhe != null)
            {
                return gimDetalhe.VL_DETALHE;
            }

            return 0m;
        }

    }
}