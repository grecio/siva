using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Entrar()
        {
            return RedirectToAction("Index", "Principal");
        }            
    }
}
