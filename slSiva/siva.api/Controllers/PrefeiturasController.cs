using siva.api.Filters;
using System;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class PrefeiturasController : BaseController
    {

        private readonly BLL.BLLPrefeitura bpPrefeitura;

        public PrefeiturasController()
        {
            bpPrefeitura = new BLL.BLLPrefeitura();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            var dt = bpPrefeitura.Listar();

            return View(dt);
        }

        [SessionExpire]
        public ActionResult Novo()
        {
            return View(UsuarioLogado);
        }

        [SessionExpire]
        public ActionResult Editar(decimal Id)
        {
            try
            {
                var prefeitura = bpPrefeitura.Selecionar(Id);

                return View(prefeitura);

            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);

                return RedirectToAction("Index");
            }
        }


        [SessionExpire]
        public ActionResult Selecionar(decimal Id)
        {
            try
            {
                var prefeitura = bpPrefeitura.Selecionar(Id);

                return View(prefeitura);

            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);

                return RedirectToAction("Index");
            }
        }

        [SessionExpire]
        public ActionResult Excluir(decimal Id)
        {
            try
            {
                bpPrefeitura.Excluir(Id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);

                return RedirectToAction("Index");
            }
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Registrar([System.Web.Http.FromBody]Dominio.Prefeitura prefeitura)
        {
            try
            {

                bpPrefeitura.Incluir(prefeitura);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                return RedirectToAction("Novo");
            }
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Alterar([System.Web.Http.FromBody]Dominio.Prefeitura prefeitura)
        {
            try
            {
                    
                bpPrefeitura.Atualizar(prefeitura);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                return RedirectToAction("Editar", new { Id = prefeitura.SQ_PREFEITURA});
            }
        }
    }
}