using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace siva.api.Controllers
{
    public class BaseController : Controller
    {
        public Dominio.Usuario UsuarioLogado
        {
            get
            {
                
                if (Session["UsuarioLogado"] != null)
                {
                    return Session["UsuarioLogado"] as Dominio.Usuario;
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

        public void ShowMsg(string mensagem)
        {

            mensagem = HttpUtility.JavaScriptStringEncode(mensagem);
            
            TempData["msg"] = string.Format("alert('{0}');", mensagem);
        }        

    }



}
