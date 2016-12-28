using siva.api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class RemetenteCteController : BaseController
    {
        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }
    }
}