using siva.api.Filters;
using siva.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class TomadorRecebedorCteController : BaseController
    {
        private readonly BLL.BLLCteTomadorRecebedor bpTomadorRecebedor;

        public TomadorRecebedorCteController()
        {
            bpTomadorRecebedor = new BLL.BLLCteTomadorRecebedor();
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

                var cteTomadorRecebedorList = bpTomadorRecebedor.Listar(CnpjRemetente, CnpjEmitente, CnpjDestinatario,
                                                            CnpjTomadorServico, CnpjTomadorExpedidor, CnpjTomadorRecebedor,
                                                            dataInicial, dataFinal, pCdMunicipio);

                var lista = new List<CteViewModel>();

                foreach (var item in cteTomadorRecebedorList)
                {
                    lista.Add(new CteViewModel() { TomadorRecebedor = item });
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