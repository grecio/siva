using CommonFrameWork;
using Dominio;
using System.Collections.Generic;

namespace BLL
{
    public class BLLUsuario
    {
        public IEnumerable<Usuario> Listar()
        {
            using (var dao = new DAL.DbUsuario())
            {
                return dao.Listar();
            }
        }

        public Usuario Selecionar(decimal sqUsuario)
        {
            using (var dao = new DAL.DbUsuario())
            {
                return dao.Selecionar(sqUsuario);
            }
        }

        public Usuario EfetuarLogin(string Login, string Senha)
        {
            using (var dao = new DAL.DbUsuario())
            {
                Validador.Validar(!string.IsNullOrWhiteSpace(Login), "Informe o login.");
                Validador.Validar(!string.IsNullOrWhiteSpace(Login), "Informe a senha.");

                var usuario = dao.EfetuarLogon(Login, Senha);

                Validador.Validar(usuario.SQ_USUARIO > 0, "Nenhum usuário encontrado para o login/senha informados.");

                return usuario;
            }
        }

        public IEnumerable<decimal> RetornaPrefeiturasPorUsuario(decimal SQ_USUARIO)
        {
            using (var dao = new DAL.DbUsuario())
            {
                return dao.RetornaPrefeiturasPorUsuario(SQ_USUARIO);
            }
        }

        public void AtualizarSenha(string Senha, decimal SQ_USUARIO)
        {
            using (var dao = new DAL.DbUsuario())
            {
                Validador.Validar(!string.IsNullOrWhiteSpace(Senha), "Informe a senha.");
                Validador.Validar(SQ_USUARIO > 0, "Informe o usuário.");

                dao.AtualizarSenha(Senha, SQ_USUARIO);
            }
        }

        public void Incluir(Usuario usuario)
        {
            using (var dao = new DAL.DbUsuario())
            {

                Validador.Validar(!string.IsNullOrWhiteSpace(usuario.NM_USUARIO), "Informe o nome do usuário.");
                Validador.Validar(!string.IsNullOrWhiteSpace(usuario.LOGIN), "Informe o login.");
                Validador.Validar(!string.IsNullOrWhiteSpace(usuario.SENHA), "Informe a senha.");

                dao.Incluir(usuario);                
            }
        }

        public void Excluir(decimal SQ_USUARIO)
        {
            using (var dao = new DAL.DbUsuario())
            {

                Validador.Validar(SQ_USUARIO > 0, "Informe o usuário.");

                dao.Excluir(SQ_USUARIO);
            }
        }

    }
}
