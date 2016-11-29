using siva.api.Filters;
using System;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly BLL.BLLUsuario bpUsuario;

        public UsuarioController()
        {
            this.bpUsuario = new BLL.BLLUsuario();
        }

        [SessionExpire]
        public ActionResult Alterar([System.Web.Http.FromBody]Dominio.Usuario usuario)
        {
            try
            {
                bpUsuario.AtualizarSenha(usuario.SENHA, UsuarioLogado.SQ_USUARIO);

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
                var usuarioList = bpUsuario.Listar();

                return View(usuarioList);

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Registrar([System.Web.Http.FromBody]Dominio.Usuario usuario)
        {
            try
            {
                bpUsuario.Incluir(usuario);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                return RedirectToAction("Novo");
            }            
        }

        [SessionExpire]
        public ActionResult Novo()
        {
            return View(UsuarioLogado);
        }

        [SessionExpire]
        [HttpPost]
        public JsonResult Excluir([System.Web.Http.FromBody]Dominio.Usuario usuario)
        {
            try
            {
                bpUsuario.Excluir(usuario.SQ_USUARIO);

                return Json(new { result = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }
        }

    }
}
