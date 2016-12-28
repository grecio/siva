using siva.api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class EmitenteCteController : BaseController
    {
        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }
    }
}