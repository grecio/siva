using System.Web.Mvc;

namespace siva.api.Filters
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session["UsuarioLogado"] == null)
            {

                filterContext.Result = new RedirectResult("~/Login/Index");

                return;                
            }

            base.OnActionExecuting(filterContext);
        }

    }
}