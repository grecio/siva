using Dominio;
using System.Collections.Generic;

namespace siva.api.Models
{
    public class ContadorContribuinteViewModel
    {
        public Contador Contador { get; set; }
        public IEnumerable<Contribuinte> ContribuinteList { get; set; }
    }
}