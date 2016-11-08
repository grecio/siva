using siva.api.Filters;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly bll.Usuario bpUsuario;

        public UsuarioController()
        {
            this.bpUsuario = new bll.Usuario();
        }

        [SessionExpire]
        public ActionResult Alterar([System.Web.Http.FromBody]presenter.Usuario usuario)
        {
            try
            {
                bpUsuario.AtualizarSenha(usuario.Senha, UsuarioLogado.Id);

                ShowMsg("Senha alterada com sucesso!");

                return RedirectToAction("AlterarSenha");
            }
            catch 
            {
                return RedirectToAction("AlterarSenha");
            }
        }

        [SessionExpire]
        public ActionResult AlterarSenha()
        {
            return View(UsuarioLogado);
        }

        [SessionExpire]
        public ActionResult Index()
        {
            try
            {
                var dt = bpUsuario.Listar();

                return View(dt);

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
      
    }
}
