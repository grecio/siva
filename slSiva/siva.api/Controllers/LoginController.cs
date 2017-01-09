using System;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class LoginController : Controller
    {
        private readonly BLL.BLLUsuario bpUsuario;

        public LoginController()
        {
            this.bpUsuario = new BLL.BLLUsuario();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar([System.Web.Http.FromBody]Dominio.Usuario usuario)
        {
            //try
            //{
            var usuarioDb = bpUsuario.EfetuarLogin(usuario.LOGIN, usuario.SENHA);

            if (usuarioDb.SQ_USUARIO > 0)
            {
                Session["UsuarioLogado"] = usuarioDb;
            }

            return RedirectToAction("Index", "Principal");
            //}
            //catch (Exception ex)
            //{
            //    return RedirectToAction("Index");
            //}            
        }            
    }
}
