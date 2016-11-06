﻿using System;
using System.Web.Mvc;
using System.Linq;

namespace siva.api.Controllers
{
    public class LoginController : BaseController
    {
        private readonly bll.Usuario bpUsuario;

        public LoginController()
        {
            this.bpUsuario = new bll.Usuario();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Entrar([System.Web.Http.FromBody]presenter.Usuario usuario)
        {
            try
            {
                var dt = bpUsuario.EfetuarLogin(usuario.Login, usuario.Senha);

                if (dt.Count > 0)
                {
                    UsuarioLogado = new presenter.Usuario(dt[0]);
                }

                return Json(new { result = UsuarioLogado});
            }
            catch (Exception ex)
            {
                return Json(new { ex = ex.Message });
            }            
        }            
    }
}
