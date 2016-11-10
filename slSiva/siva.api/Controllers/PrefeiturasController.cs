using siva.api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class PrefeiturasController : BaseController
    {

        private readonly bll.Prefeitura bpPrefeitura;

        public PrefeiturasController()
        {
            bpPrefeitura = new bll.Prefeitura();
        }

        [SessionExpire]
        public ActionResult Index()
        {

            try
            {
                var dt = bpPrefeitura.Listar();

                return View(dt);

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        [SessionExpire]
        public ActionResult Novo()
        {
            return View(UsuarioLogado);
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Registrar([System.Web.Http.FromBody]presenter.Prefeitura prefeitura)
        {
            try
            {

                bpPrefeitura.Incluir(prefeitura.Nome, prefeitura.Prefeito,
                        prefeitura.SecretarioTributacao, prefeitura.Contador,
                        prefeitura.Logradouro, prefeitura.Numero, prefeitura.Complemento, prefeitura.Contato, prefeitura.NumeroHabitantes, prefeitura.Territorio);                

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                return RedirectToAction("Novo");
            }
        }
    }
}