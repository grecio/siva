using siva.api.Filters;
using siva.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class DestinatarioCteController : BaseController
    {
        private readonly BLL.BLLCteDestinatario bpCteDestinatario;

        public DestinatarioCteController()
        {
            bpCteDestinatario = new BLL.BLLCteDestinatario();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult Consultar(string CnpjRemetente, string CnpjEmitente, string CnpjDestinatario,
                                        string CnpjTomadorServico, string CnpjTomadorExpedidor, string CnpjTomadorRecebedor,
                                        string dataInicial, string dataFinal, decimal? pCdMunicipio)
        {

            //try
            //{

            var cteDestinatarioList = bpCteDestinatario.Listar(CnpjRemetente, CnpjEmitente, CnpjDestinatario,
                                                        CnpjTomadorServico, CnpjTomadorExpedidor, CnpjTomadorRecebedor,
                                                        dataInicial, dataFinal, pCdMunicipio);

            var lista = new List<CteViewModel>();

            foreach (var item in cteDestinatarioList)
            {
                lista.Add(new CteViewModel() { Destinatario = item });
            }

            return View(lista);

            //}
            //catch (Exception ex)
            //{
            //    ShowMsg(ex.Message);
            //    return RedirectToAction("Index");
            //}

        }
    }
}