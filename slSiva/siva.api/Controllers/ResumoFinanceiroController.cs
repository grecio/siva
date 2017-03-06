using siva.api.Filters;
using siva.api.Models;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Collections;

namespace siva.api.Controllers
{
    public class ResumoFinanceiroController : BaseController
    {

        private readonly BLL.BLLResumoFinanceiro bpResumoFinanceiro;
        private readonly BLL.BLLMunicipio bpMunicipio;

        public ResumoFinanceiroController()
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
                var resumoList = bpResumoFinanceiro.RetornaResumoFinanceiro(codigoMunicipio, cnpj, anoInicial, AnoFinal);

                if (resumoList.Any())                
                    return View(new ResumoFinanceiroViewModel() {  ResumoList = resumoList.ToList(), AnoInicial = anoInicial, AnoFinal = AnoFinal, CodigoMunicipio = codigoMunicipio});

                ShowMsg("Nenhum registro encontrado.");
                return RedirectToAction("Index");

            }
            catch(Exception ex)
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

        [SessionExpire]
        [HttpGet]
        public JsonResult GerarGrafico(long? codigoMunicipio, string cnpj, int anoInicial, int AnoFinal)
        {
            try
            {
                var resumoList = bpResumoFinanceiro.RetornaResumoFinanceiro(codigoMunicipio, cnpj, anoInicial, AnoFinal);

                if (resumoList.Any())                    
                    return Json(new { result = "ok", grafico = resumoList.FirstOrDefault() }, JsonRequestBehavior.AllowGet);

                return Json(new { result = "none" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }
        }

    }
}