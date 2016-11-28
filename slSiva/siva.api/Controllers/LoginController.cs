using System;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class LoginController : Controller
    {
        private readonly BLL.Usuario bpUsuario;

        public LoginController()
        {
            this.bpUsuario = new BLL.Usuario();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar([System.Web.Http.FromBody]Dominio.Usuario usuario)
        {
            try
            {
                var dt = bpUsuario.EfetuarLogin(usuario.Login, usuario.Senha);

                if (dt.Count > 0)
                {
                    Session["UsuarioLogado"] = new Dominio.Usuario(dt[0]);
                }

                return RedirectToAction("Index", "Principal");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }            
        }            
    }
}
