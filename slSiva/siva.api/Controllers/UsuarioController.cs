using siva.api.Filters;
using siva.api.Models;
using System;
using System.Web.Mvc;
using System.Linq;
using Dominio;
using System.Collections.Generic;

namespace siva.api.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly BLL.BLLUsuario bpUsuario;
        private readonly BLL.BLLPrefeitura bpPrefeitura;

        public UsuarioController()
        {
            bpUsuario = new BLL.BLLUsuario();
            bpPrefeitura = new BLL.BLLPrefeitura();

        }

        [SessionExpire]
        public ActionResult Alterar([System.Web.Http.FromBody]Dominio.Usuario usuario)
        {
            try
            {
                bpUsuario.AtualizarSenha(usuario.SENHA, UsuarioLogado.SQ_USUARIO);

                ShowMsg("Senha alterada com sucesso!");

                return RedirectToAction("AlterarSenha");
            }
            catch
            {
                return RedirectToAction("AlterarSenha");
            }            
        }        

        [SessionExpire]
        public ActionResult AlterarSenha()
        {
            return View(UsuarioLogado);
        }

        [SessionExpire]
        public ActionResult Index()
        {
            try
            {
                var usuarioList = bpUsuario.Listar();

                return View(usuarioList);

            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        [SessionExpire]
        public ActionResult VincularPrefeitura(decimal Id)
        {
            try
            {
                var usuarioDb = bpUsuario.Selecionar(Id);
                var prefeturasDb = bpPrefeitura.Listar().ToList();
                var usuarioPrefeituraDb = bpUsuario.RetornaPrefeiturasPorUsuario(Id).ToList();

                var usuarioPrefeituraViewModel = new UsuarioPrefeituraViewModel()
                {
                    Usuario = usuarioDb,
                    PrefeituraList = prefeturasDb,
                    UsuarioPrefeituraList = usuarioPrefeituraDb

                };

                return View(usuarioPrefeituraViewModel);

            }
            catch (Exception )
            {

                throw;
            }            
        }

        [HttpPost]
        [SessionExpire]        
        public JsonResult Vincular(UsuarioPrefeituraViewModel usuarioPrefeituraViewModel)
        {
            try
            {
                var usuarioPrefeitura = new UsuarioPrefeitura();


                usuarioPrefeitura.Usuario = usuarioPrefeituraViewModel.Usuario;
                usuarioPrefeitura.PrefeituraList = new List<Prefeitura>();

                if (usuarioPrefeituraViewModel.UsuarioPrefeituraList != null)
                {
                    foreach (var sqPrefeitura in usuarioPrefeituraViewModel.UsuarioPrefeituraList)
                    {
                        usuarioPrefeitura.PrefeituraList.Add(new Prefeitura() { SQ_PREFEITURA = sqPrefeitura });
                    }
                }

                bpUsuario.VincularPrefeituras(usuarioPrefeitura);
                                
                                                
                return Json(new { Result = "Ok" });
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);

                return null;
            }
        }

        [SessionExpire]
        [HttpPost]
        public ActionResult Cadastrar([System.Web.Http.FromBody]Dominio.Usuario usuario)
        {
            try
            {

                var admin = Convert.ToBoolean(usuario.ADMINISTRADOR);

                usuario.ADMINISTRADOR = admin ? "S" : "N";
                   
                bpUsuario.Incluir(usuario);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                return RedirectToAction("Novo");
            }            
        }

        [SessionExpire]
        public ActionResult Novo()
        {
            return View(UsuarioLogado);
        }

        [SessionExpire]
        [HttpPost]
        public JsonResult Excluir([System.Web.Http.FromBody]Dominio.Usuario usuario)
        {
            try
            {
                bpUsuario.Excluir(usuario.SQ_USUARIO);

                return Json(new { result = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }
        }

    }
}
