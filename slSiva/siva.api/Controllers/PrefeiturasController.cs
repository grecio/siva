using siva.api.Filters;
using siva.api.Models;
using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class PrefeiturasController : BaseController
    {

        private readonly BLL.BLLPrefeitura bpPrefeitura;
        private readonly BLL.BLLMunicipio bpMunicipio;

        public PrefeiturasController()
        {
            bpPrefeitura = new BLL.BLLPrefeitura();
            bpMunicipio = new BLL.BLLMunicipio();
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
                var prefeituraViewModel = new PrefeituraViewModel();

                prefeituraViewModel.Prefeitura = bpPrefeitura.Selecionar(Id);
                prefeituraViewModel.MunicipioList = bpMunicipio.RetornaMunicipio().ToList();


                return View(prefeituraViewModel);

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

        [SessionExpire]
        [HttpGet]
        public JsonResult PreencherMunicipio()
        {
            try
            {
                var municipioList = bpMunicipio.RetornaMunicipio().ToList();

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