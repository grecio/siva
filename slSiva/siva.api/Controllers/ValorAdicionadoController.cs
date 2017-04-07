using siva.api.Filters;
using System;
using System.Collections;
using System.Web.Mvc;
using System.Linq;
using Dominio;
using siva.api.Models;
using System.Collections.Generic;

namespace siva.api.Controllers
{
    public class ValorAdicionadoController : BaseController
    {
        private readonly BLL.BLLMunicipio bpMunicipio;
        private readonly BLL.BLLValorAdicionado bpValorAdicionado;

        public ValorAdicionadoController()
        {
            bpMunicipio = new BLL.BLLMunicipio();
            bpValorAdicionado = new BLL.BLLValorAdicionado();
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

        [SessionExpire]
        public ActionResult Consultar()
        {
            var valorAdicionadoList = bpValorAdicionado.RetornaCabecalhoValorAdicionado();

            var valorAdicionadoViewModelList = new List<ValorAdicionadoViewModel>();

            if (valorAdicionadoList.Any())
            {
                foreach (var item in valorAdicionadoList)
                {
                    valorAdicionadoViewModelList.Add(new ValorAdicionadoViewModel() { Cabecalho = item });
                }
            }

            return View(valorAdicionadoViewModelList);
        }


        [SessionExpire]
        public ActionResult Detalhar(decimal numeroProcesso)
        {

            var valorAdicionadoDetList = bpValorAdicionado.RetornarDetalhamentoValorAdicionado(numeroProcesso);

            var valorAdicionadoViewModelList = new List<ValorAdicionadoViewModel>();

            if (valorAdicionadoDetList.Any())
            {
                foreach (var item in valorAdicionadoDetList)
                {
                    valorAdicionadoViewModelList.Add(new ValorAdicionadoViewModel() { Detalhamento = item });
                }
            }

            return View(valorAdicionadoViewModelList);
        }


        [SessionExpire]
        public ActionResult Executar(decimal CD_MUNICIPIO, string tipoCalculo, int anoBase)
        {
            try
            {
                var processamento = bpValorAdicionado.ExecutarProcessamento(CD_MUNICIPIO, tipoCalculo, anoBase);

                ShowConfirm(string.Format("O PROCESSO DO VALOR ADICIONADO DE Nº {0} GERADO COM SUCESSO!\nDESEJA EXIBIR OS DETALHES?", processamento));

                TempData["Processamento"] = processamento;

                return View("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);

                return View("Index");
            }
        }       
    }
}
