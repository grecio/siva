using siva.api.Filters;
using siva.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class TomadorExpedidorCteController : BaseController
    {

        private readonly BLL.BLLCteTomadorExpedidor bpTomadorExpedidor;

        public TomadorExpedidorCteController()
        {
            bpTomadorExpedidor = new BLL.BLLCteTomadorExpedidor();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult Consultar(string CnpjRemetente, string CnpjEmitente, string CnpjDestinatario,
                                string CnpjTomadorServico, string CnpjTomadorExpedidor, string CnpjTomadorRecebedor,
                                DateTime? dataInicial, DateTime? dataFinal, decimal? pCdMunicipio)
        {

            try
            {

                var cteTomadorExpedidorList = bpTomadorExpedidor.Listar(CnpjRemetente, CnpjEmitente, CnpjDestinatario,
                                                            CnpjTomadorServico, CnpjTomadorExpedidor, CnpjTomadorRecebedor,
                                                            dataInicial, dataFinal, pCdMunicipio);

                var lista = new List<CteViewModel>();

                foreach (var item in cteTomadorExpedidorList)
                {
                    lista.Add(new CteViewModel() { TomadorExpedidor = item });
                }

                return View(lista);

            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                return RedirectToAction("Index");
            }

        }
    }
}