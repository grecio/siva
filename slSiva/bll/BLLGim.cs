using CommonFrameWork;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLGim
    {
        public IEnumerable<Referencia> RetornarReferenciaPorInscricao(string ie)
        {
            using (var dao = new DAL.DbGIM())
            {
                return dao.RetornarReferenciaPorInscricao(ie);
            }
        }

        public IEnumerable<GIM> RetornaGIMPorInscricaoReferencia(string ie, decimal referencia)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(ie), "Informe a inscrição estadual.");

            using (var dao = new DAL.DbGIM())
            {
                return dao.RetornaGIMPorInscricaoReferencia(ie, referencia);
            }
        }      

    }
}
