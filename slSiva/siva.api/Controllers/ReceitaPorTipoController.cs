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
    public class ReceitaPorTipoController : BaseController
    {

        private readonly BLL.BLLResumoFinanceiro bpResumoFinanceiro;
        private readonly BLL.BLLMunicipio bpMunicipio;

        public ReceitaPorTipoController()
        {
            bpResumoFinanceiro = new BLL.BLLResumoFinanceiro();
            bpMunicipio = new BLL.BLLMunicipio();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult Consultar(long? codigoMunicipio, string cnpj, int anoInicial, int AnoFinal)
        {
            try
            {
                var resumoList = bpResumoFinanceiro.RetornaResumoFinanceiroPorTipo(codigoMunicipio, cnpj, anoInicial, AnoFinal);

                if (resumoList.Any())
                    return View(new ResumoFinanceiroPorTipoViewModel() { ResumoList = resumoList.ToList(), AnoInicial = anoInicial, AnoFinal = AnoFinal, CodigoMunicipio = codigoMunicipio });

                ShowMsg("Nenhum registro encontrado.");
                return RedirectToAction("Index");

            }
            
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                return RedirectToAction("Index");
            }
        }

        [SessionExpire]
        [HttpGet]
        public JsonResult PreencherMunicipio()
        {
            try
            {
                var municipioList = bpMunicipio.RetornaMunicipio().ToList();

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