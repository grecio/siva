using CommonFrameWork;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLValorAdicionado
    {
        public decimal ExecutarProcessamento(decimal codigoMunicipio, string tipoCalculo, int anoBase)
        {

            Validador.Validar(codigoMunicipio > 0, "Informe o município.");
            Validador.Validar(!string.IsNullOrWhiteSpace(tipoCalculo), "Informe o tipo de cálculo.");
            Validador.Validar(anoBase > 0, "Informe o ano.");            

            using (var dao = new DAL.DbValorAdicionado())
            {
                return dao.ExecutarProcessamento(codigoMunicipio, tipoCalculo, anoBase);
            }
        }

        public IEnumerable<ValorAdicionadoCabecalho> RetornaCabecalhoValorAdicionado()
        {
            using (var dao = new DAL.DbValorAdicionado())
            {
                return dao.RetornaCabecalhoValorAdicionado();
            }
        }

        public IEnumerable<ValorAdicionadoDetalhamento> RetornarDetalhamentoValorAdicionado(decimal numeroProcesso)
        {
            Validador.Validar(numeroProcesso > 0, "Informe o Nº do processamento do valor adicionado.");

            using (var dao = new DAL.DbValorAdicionado())
            {
                return dao.RetornarDetalhamentoValorAdicionado(numeroProcesso);
            }
        }
    }
}
