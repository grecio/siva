using System;
using System.Web.Mvc;
using siva.api.Filters;
using siva.api.Models;

namespace siva.api.Controllers
{
    public class ContadorController : BaseController
    {

        private readonly BLL.BLLContador bpContador;

        public ContadorController()
        {
            bpContador = new BLL.BLLContador();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            try
            {
                var contadorList = bpContador.Listar();
                return View(contadorList);

            }
            catch
            {
                throw;
            }

        }

        [SessionExpire]
        public ActionResult Selecionar(decimal Id)
        {
            try
            {
                var contadorDb = bpContador.Selecionar(Id);

                var contadorViewModel = new ContadorViewModel()
                {
                    Contador = contadorDb
                };

                return View(contadorViewModel);

            }
            catch
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
        public ActionResult Cadastrar([System.Web.Http.FromBody]Dominio.Contador contador)
        {
            try
            {

                bpContador.Incluir(contador);                

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
        public JsonResult Excluir([System.Web.Http.FromBody]Dominio.Contador contador)
        {
            try
            {
                bpContador.Excluir(contador.SQ_CONTADOR);
                
                return Json(new { result = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }
        }

        [SessionExpire]
        public ActionResult ExibirContribuinte(decimal Id)
        {
            try
            {
                var contadorDb = bpContador.Selecionar(Id);
                var contadorContribuinteListDb = bpContador.RetornaContribuintePorContador(Id);

                var contadorContribuinteViewModel = new ContadorContribuinteViewModel()
                {
                    Contador = contadorDb,
                    ContribuinteList = contadorContribuinteListDb                    

                };

                return View(contadorContribuinteViewModel);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}