using CommonFrameWork;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLResumoFinanceiro
    {
        public IEnumerable<ResumoFinanceiro> RetornaResumoFinanceiro(long? codigoMunicipio, string Cnpj, int AnoInicial, int AnoFinal)
        {
            Validador.Validar(codigoMunicipio> 0, "Informe o Município.");            
            Validador.Validar(AnoInicial > 0, "Informe o ano inicial.");
            Validador.Validar(AnoFinal > 0, "Informe o ano final.");

            Validador.Validar(AnoInicial <= AnoFinal, "O ano inicial deve ser menor ou igual ao ano final.");


            using (var dao = new DAL.DbResumoFinanceiro())
            {
                return dao.RetornaResumoFinanceiro(codigoMunicipio, Cnpj, AnoInicial, AnoFinal);
            }
        }

        public IEnumerable<ResumoFinanceiroPorTipo> RetornaResumoFinanceiroPorTipo(long? codigoMunicipio, string Cnpj, int AnoInicial, int AnoFinal)
        {
            Validador.Validar(codigoMunicipio > 0, "Informe o Município.");
            Validador.Validar(AnoInicial > 0, "Informe o ano inicial.");
            Validador.Validar(AnoFinal > 0, "Informe o ano final.");

            Validador.Validar(AnoInicial <= AnoFinal, "O ano inicial deve ser menor ou igual ao ano final.");


            using (var dao = new DAL.DbResumoFinanceiro())
            {
                return dao.RetornaResumoFinanceiroPorTipo(codigoMunicipio, Cnpj, AnoInicial, AnoFinal);
            }
        }
    }
}
