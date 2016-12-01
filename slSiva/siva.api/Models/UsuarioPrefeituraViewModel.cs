using Dominio;
using System.Collections.Generic;

namespace siva.api.Models
{
    public class UsuarioPrefeituraViewModel
    {
        public Usuario Usuario { get; set; }
        public List<Prefeitura> PrefeituraList { get; set; }
        public List<decimal> UsuarioPrefeituraList { get; set; }
    }
}