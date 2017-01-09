using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siva.api.Models
{
    public class CteViewModel
    {
        public CteRemetente Remetente { get; set; }
        public CteDestinatario Destinatario { get; set; }
        public CteEmitente Emitente { get; set; }
        public CteTomadorServico TomadorServico { get; set; }
        public CteTomadorExpedidor TomadorExpedidor { get; set; }
        public CteTomadorRecebedor TomadorRecebedor { get; set; }
    }    
}