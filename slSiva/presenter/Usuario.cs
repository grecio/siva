using System;

namespace Dominio
{
    public class Usuario
    {
        public decimal SQ_USUARIO { get; set; }
        public string NM_USUARIO { get; set; }
        public string LOGIN { get; set; }
        public string SENHA { get; set; }
        public DateTime DT_INCLUSAO { get; set; }
        public string NM_USUARIO_INCLUSAO { get; set; }
        public DateTime DT_ALTERACAO { get; set; }
        public string NM_USUARIO_ALTERACAO { get; set; }
        public string ADMINISTRADOR { get; set; }
        
        public string EhAdministrador
        {
            get
            {
                return ADMINISTRADOR == "S" ? "Sim" : "Não";
            }
        }
              
    }
}
