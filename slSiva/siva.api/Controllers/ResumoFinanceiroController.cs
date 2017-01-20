using siva.api.Filters;
using siva.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace siva.api.Controllers
{
    public class ResumoFinanceiroController : Controller
    {

        private readonly BLL.BLLResumoFinanceiro bpResumoFinanceiro;

        public ResumoFinanceiroController()
        {
            bpResumoFinanceiro = new BLL.BLLResumoFinanceiro();
        }

        [SessionExpire]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult Consultar(string cnpj, int anoInicial, int AnoFinal)
        {
            try
            {
                var resumo = bpResumoFinanceiro.RetornaResumoFinanceiro(cnpj, anoInicial, AnoFinal);
                return View(new ResumoFinanceiroViewModel() {  Resumo = resumo});
                                
            }
            catch
            {
                throw;
            }
        }
    }
}