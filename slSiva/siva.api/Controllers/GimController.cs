using System;
using System.Web.Mvc;
using siva.api.Filters;
using System.Collections;
using System.Collections.Generic;
using siva.api.Models;

namespace siva.api.Controllers
{
    public class GimController : BaseController
    {
        private readonly BLL.BLLGim bpGim;

        public GimController()
        {
            bpGim = new BLL.BLLGim();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpire]
        public JsonResult PreencherReferencia(string ie)
        {
            try
            {
                var referenciasList = bpGim.RetornarReferenciaPorInscricao(ie);

                var lista = new ArrayList();

                foreach (var item in referenciasList)
                {
                    lista.Add(new { id = item.NU_REFERENCIA, text = item.NU_REFERENCIA });
                }

                return Json(new { result = "ok", referenciasList = lista });
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }
        }

        [SessionExpire]
        public ActionResult Consultar(string ie, decimal referencia)
        {
            try
            {
                var gimList = bpGim.RetornaGIMPorInscricaoReferencia(ie, referencia);

                var lista = new List<GIMViewModel>();

                foreach (var item in gimList)
                {
                    lista.Add(new GIMViewModel() { Gim = item });
                }

                return View(lista);


            }
            catch
            {
                throw;
            }
        }

    }
}
