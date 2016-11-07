using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class UsuarioController : BaseController
    {

        public ActionResult AlterarSenha()
        {
            return View(UsuarioLogado);
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: api/Usuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
