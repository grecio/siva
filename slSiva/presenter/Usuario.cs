namespace Dominio
{
    public class Usuario : EntidadeBase
    {        
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }


        public Usuario(DAL.DsUsuario.UsuarioRow row)
        {
            Id = row.SQ_USUARIO;
            Nome = row.NM_USUARIO;
            Login = row.LOGIN;            
        }

        public Usuario()
        {

        }
    }
}
