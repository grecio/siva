using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siva.api.Models
{
    public class GIMViewModel
    {
        public GIM Gim { get; set; }
        public List<GIMDetalhe> GimDetalhe { get; set; }        
    
        public decimal RetornaValorDetalhamentoPorCodigo(decimal codigo)
        {
            var gimDetalhe = GimDetalhe.SingleOrDefault(item => item.CD_DETALHE == codigo);

            if (gimDetalhe != null)
            {
                return gimDetalhe.VL_DETALHE;
            }

            return 0m;
        }

    }
}