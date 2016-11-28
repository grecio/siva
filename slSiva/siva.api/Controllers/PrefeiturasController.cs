using siva.api.Filters;
using System;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class PrefeiturasController : BaseController
    {

        private readonly BLL.Prefeitura bpPrefeitura;

        public PrefeiturasController()
        {
            bpPrefeitura = new BLL.Prefeitura();
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
        public ActionResult Registrar([System.Web.Http.FromBody]Dominio.Prefeitura prefeitura)
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