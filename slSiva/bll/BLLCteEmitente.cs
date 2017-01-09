using CommonFrameWork;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCteEmitente
    {

        public IEnumerable<CteEmitente> Listar(string pNuCnpjRemetente, string pNuCnpjEmitente, string pNuCnpjDestinatario,
                                            string pNuCnpjTomadorServico, string pNuCnpjTomExpedidor, string pNuCnpjTomRecebedor,
                                            DateTime? pDtInicioIntervalo, DateTime? pDtFinalIntervalo, decimal? pCdMunicipio)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(pNuCnpjEmitente) , "Informe o CNPJ do emitente.");

            using (var dao = new DAL.DbCteEmitente())
            {

                Validador.Validar(Validador.ValidarData(pDtInicioIntervalo.Value.ToString("dd/MM/yyyy")), "Informe uma data inicial válida.");
                Validador.Validar(Validador.ValidarData(pDtFinalIntervalo.Value.ToString("dd/MM/yyyy")), "Informe uma data final válida.");

                if (pDtInicioIntervalo.HasValue && pDtFinalIntervalo.HasValue)
                {
                    Validador.Validar(pDtInicioIntervalo.Value <= pDtFinalIntervalo.Value, "A data inicial deve ser menor ou igual a data final.");
                }

                return dao.Listar(pNuCnpjRemetente, pNuCnpjEmitente, pNuCnpjDestinatario,
                    pNuCnpjTomadorServico, pNuCnpjTomExpedidor, pNuCnpjTomRecebedor, pDtInicioIntervalo, pDtFinalIntervalo, pCdMunicipio);
            }
        }

    }
}
