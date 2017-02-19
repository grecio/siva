using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siva.api.Models
{
    public class PrefeituraViewModel
    {
        public Prefeitura Prefeitura { get; set; }
        public List<Municipio> MunicipioList { get; set; }
    }
}