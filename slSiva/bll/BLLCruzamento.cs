using CommonFrameWork;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCruzamento
    {
        public IEnumerable<CruzamentoTipo> RetornarTipoCruzamento()
        {
            using (var dao = new DAL.DbCruzamento())
            {
                return dao.RetornarTipoCruzamento();
            }
        }

        public IEnumerable<CruzamentoCabecalho> RetornarCabecalhoCruzamento()
        {
            using (var dao = new DAL.DbCruzamento())
            {
                return dao.RetornarCabecalhoCruzamento();
            }
        }

        public IEnumerable<CruzamentoDetalhamento> RetornarDetalhamentoCruzamento(decimal numeroProcesso)
        {
            Validador.Validar(numeroProcesso > 0, "Informe o número do processamento.");

            using (var dao = new DAL.DbCruzamento())
            {
                return dao.RetornarDetalhamentoCruzamento(numeroProcesso);
            }
        }

        public void ExecutarCruzamento(decimal codigoMunicipio, int tipoCruzamento, int anoInicial, int anoFinal)
        {
            Validador.Validar(codigoMunicipio > 0, "Informe o município.");
            Validador.Validar(tipoCruzamento > 0, "Informe o tipo de cruzamento.");
            Validador.Validar(anoInicial > 0, "Informe o ano inicial.");
            Validador.Validar(anoFinal > 0, "Informe o ano final.");
            Validador.Validar(anoInicial <= anoFinal, "O ano inicial deve ser menor ou igual ao ano final.");

            using (var dao = new DAL.DbCruzamento())
            {
                dao.ExecutarCruzamento(codigoMunicipio, tipoCruzamento, anoInicial, anoFinal);
            }
        }
    }
}
