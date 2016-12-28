using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Dominio.Referencia;

namespace siva.api.Models
{
    public class InformativoFiscalViewModel
    {
        public ReferenciaInformativoFiscal Referencia { get; set; }
        public Dominio.InformativoFiscal Informativo { get; set; }
    }
}