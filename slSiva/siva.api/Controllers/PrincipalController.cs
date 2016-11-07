using siva.api.Filters;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class PrincipalController : BaseController
    {
        [SessionExpire]
        public ActionResult Index()
        {
            return View(UsuarioLogado);
        }
    }
}
