using CommonFrameWork;

namespace bll
{
    public class Usuario
    {
        public dal.DsUsuario.UsuarioDataTable Listar()
        {
            using (var adp = new dal.DsUsuarioTableAdapters.UsuarioTableAdapter())
            {
                return adp.Listar();
            }
        }

        public dal.DsUsuario.UsuarioDataTable Selecionar(decimal sqUsuario)
        {
            using (var adp = new dal.DsUsuarioTableAdapters.UsuarioTableAdapter())
            {
                return adp.Selecionar(sqUsuario);
            }
        }

        public dal.DsUsuario.UsuarioDataTable EfetuarLogin(string Login, string Senha)
        {
            using (var adp = new dal.DsUsuarioTableAdapters.UsuarioTableAdapter())
            {
                Validador.Validar(!string.IsNullOrWhiteSpace(Login), "Informe o login.");
                Validador.Validar(!string.IsNullOrWhiteSpace(Login), "Informe a senha.");

                var dt =  adp.EfetuarLogin(Login, Senha);

                Validador.Validar(dt.Count > 0, "Nenhum usuário encontrado para o login/senha informados.");

                return dt;
            }
        }

        public void AtualizarSenha(string Senha, decimal SQ_USUARIO)
        {
            using (var adp = new dal.DsUsuarioTableAdapters.UsuarioTableAdapter())
            {
                Validador.Validar(!string.IsNullOrWhiteSpace(Senha), "Informe a senha.");
                Validador.Validar(SQ_USUARIO > 0, "Informe o usuário.");

                adp.AtualizarSenha(Senha, SQ_USUARIO);
            }
        }

        public void Incluir(string NM_USUARIO, string LOGIN, string SENHA)
        {
            using (var adp = new dal.DsUsuarioTableAdapters.UsuarioTableAdapter())
            {

                Validador.Validar(!string.IsNullOrWhiteSpace(NM_USUARIO), "Informe o nome do usuário.");
                Validador.Validar(!string.IsNullOrWhiteSpace(LOGIN), "Informe o login.");
                Validador.Validar(!string.IsNullOrWhiteSpace(SENHA), "Informe a senha.");

                adp.Incluir(NM_USUARIO, LOGIN, SENHA);
            }
        }

        public void Excluir(decimal SQ_USUARIO)
        {
            using (var adp = new dal.DsUsuarioTableAdapters.UsuarioTableAdapter())
            {

                Validador.Validar(SQ_USUARIO > 0, "Informe o usuário.");

                adp.Excluir(SQ_USUARIO);
            }
        }
    }
}
