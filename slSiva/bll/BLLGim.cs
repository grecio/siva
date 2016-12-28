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
        public IEnumerable<Referencia.GIM> RetornarReferenciaPorInscricao(string ie)
        {
            using (var dao = new DAL.DbGIM())
            {
                return dao.RetornarReferenciaPorInscricao(ie);
            }
        }

        public IEnumerable<GIMReferencia> RetornaGIMPorInscricaoReferencia(string ie, decimal? referencia)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(ie), "Informe a inscrição estadual.");            

            using (var dao = new DAL.DbGIM())
            {
                return dao.RetornaGIMPorInscricaoReferencia(ie, referencia);
            }
        }

        public GIM RetornaConsultaGuiaMensal(string ie, decimal referencia)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(ie), "Informe a inscrição estadual.");
            Validador.Validar(referencia > 0, "Informe a referencia.");

            using (var dao = new DAL.DbGIM())
            {
                return dao.RetornaConsultaGuiaMensal(ie, referencia);
            }
        }

        public IEnumerable<GIMDetalhe> RetornaConsultaGuiaMensalDetalhe(string ie, decimal referencia)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(ie), "Informe a inscrição estadual.");            

            using (var dao = new DAL.DbGIM())
            {
                return dao.RetornaConsultaGuiaMensalDetalhe(ie, referencia);
            }
        }
    }
}
