using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace siva.api.Controllers
{
    public class BaseController : Controller
    {
        public presenter.Usuario UsuarioLogado
        {
            get
            {
                
                if (Session["UsuarioLogado"] != null)
                {
                    return Session["UsuarioLogado"] as presenter.Usuario;
                }

                return null;
            }
            set
            {
                Session["UsuarioLogado"] = value;
            }
        }

        public bool UsuarioAutenticado
        {        
            get
            {
                return UsuarioLogado != null;
            }            
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (!UsuarioAutenticado)
            {
                RedirectToAction("Index", "Logout");
            }
        }

        public void Alert(string Mensagem)
        {            
            ViewData["Alert"] = "<script type=\"text/javascript\">alert('" + Mensagem + "');</script>";
        }
    }
}
