using siva.api.Filters;
using siva.api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class InformativoFiscalController : BaseController
    {

        private readonly BLL.BLLInformativoFiscal bpInformativoFiscal;

        public InformativoFiscalController()
        {
            bpInformativoFiscal = new BLL.BLLInformativoFiscal();
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
                var referenciasList = bpInformativoFiscal.RetornarReferenciaPorInscricao(ie);

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
        public ActionResult Consultar(string ie, decimal? referencia)
        {
            try
            {
                var gimList = bpInformativoFiscal.RetornaInformativoFiscalPorInscricaoReferencia(ie, referencia);

                var lista = new List<InformativoFiscalViewModel>();

                foreach (var item in gimList)
                {
                    lista.Add(new InformativoFiscalViewModel() { Referencia = item });
                }

                return View(lista);
            }
            catch
            {
                throw;
            }
        }

        [SessionExpire]
        public ActionResult Emitir(string ie, decimal referencia)
        {
            try
            {
                var informativo = bpInformativoFiscal.RetornaInformativoFiscal(ie, referencia);

                var informativoViewModel = new InformativoFiscalViewModel()
                {
                    Informativo = informativo
                };

                return View(informativoViewModel);

            }
            catch
            {

                throw;
            }
        }

    }
}