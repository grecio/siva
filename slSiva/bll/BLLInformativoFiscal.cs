using CommonFrameWork;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLInformativoFiscal
    {
        public IEnumerable<Referencia.InformativoFiscal> RetornarReferenciaPorInscricao(string ie)
        {
            using (var dao = new DAL.DbInformativoFiscal())
            {
                return dao.RetornarReferenciaPorInscricao(ie);
            }
        }

        public IEnumerable<ReferenciaInformativoFiscal> RetornaInformativoFiscalPorInscricaoReferencia(string ie, decimal? referencia)
        {
            using (var dao = new DAL.DbInformativoFiscal())
            {
                return dao.RetornaInformativoFiscalPorInscricaoReferencia(ie, referencia);
            }
        }

        public InformativoFiscal RetornaInformativoFiscal(string ie, decimal referencia)
        {

            Validador.Validar(!string.IsNullOrWhiteSpace(ie), "Informe a inscrição estadual.");
            Validador.Validar(referencia > 0, "Informe a referência.");

            using (var dao = new DAL.DbInformativoFiscal())
            {
                return dao.RetornaInformativoFiscal(ie, referencia);
            }
        }
    }
}
