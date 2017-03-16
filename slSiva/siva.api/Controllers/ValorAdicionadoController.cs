using siva.api.Filters;
using System;
using System.Collections;
using System.Web.Mvc;
using System.Linq;

namespace siva.api.Controllers
{
    public class ValorAdicionadoController : BaseController
    {
        private readonly BLL.BLLMunicipio bpMunicipio;

        public ValorAdicionadoController()
        {
            bpMunicipio = new BLL.BLLMunicipio();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpire]
        [HttpGet]
        public JsonResult PreencherMunicipio()
        {
            try
            {

                if (UsuarioLogado == null)
                    throw new Exception("Usuário não está autenticado.");

                var municipioList = bpMunicipio.RetornaMunicipio(UsuarioLogado).ToList();

                var lista = new ArrayList();

                foreach (var item in municipioList)
                {
                    lista.Add(new { id = item.CD_MUNICIPIO_RFB, text = item.NM_MUNICIPIO_RFB });
                }

                return Json(new { result = "ok", municipioList = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }
        }

    }
}
