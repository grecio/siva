using siva.api.Filters;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class ContadorController : BaseController
    {

        private readonly BLL.BLLContador bpContador;

        public ContadorController()
        {
            bpContador = new BLL.BLLContador();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            try
            {
                var contadorList = bpContador.Listar();
                return View(contadorList);

            }
            catch
            {
                throw;
            }

        }

        [SessionExpire]
        public ActionResult Novo()
        {
            return View(UsuarioLogado);
        }

    }
}