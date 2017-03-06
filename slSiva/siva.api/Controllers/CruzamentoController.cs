using Dominio;
using siva.api.Filters;
using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class CruzamentoController : BaseController
    {

        private readonly BLL.BLLCruzamento bpCruzamento;
        private readonly BLL.BLLMunicipio bpMunicipio;

        public CruzamentoController()
        {
            bpCruzamento = new BLL.BLLCruzamento();
            bpMunicipio = new BLL.BLLMunicipio();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult Consultar()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult Executar(int CD_CRUZAMENTO, decimal CD_MUNICIPIO, int anoInicial, int anoFinal)
        {
            try
            {
                bpCruzamento.ExecutarCruzamento(CD_MUNICIPIO, CD_CRUZAMENTO, anoInicial, anoFinal);

                ShowMsg("Processamento Executado com Sucesso!");

                return View("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);

                return View("Index");
            }            
        }

        [SessionExpire]
        [HttpGet]
        public JsonResult PreencherTipoCruzamento()
        {
            try
            {
                var tipoCruzamentoList = bpCruzamento.RetornarTipoCruzamento();

                var lista = new ArrayList();

                foreach (var item in tipoCruzamentoList)
                {
                    lista.Add(new { id = item.CD_CRUZAMENTO, text = item.DC_CRUZAMENTO });
                }

                return Json(new { result = "ok", tipoCruzamentoList = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
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

    }
}
