using CommonFrameWork;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCteDestinatario
    {

        public IEnumerable<CteDestinatario> Listar(string pNuCnpjRemetente, string pNuCnpjEmitente, string pNuCnpjDestinatario,
                                            string pNuCnpjTomadorServico, string pNuCnpjTomExpedidor, string pNuCnpjTomRecebedor,
                                            string pDtInicioIntervalo, string pDtFinalIntervalo, decimal? pCdMunicipio)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(pNuCnpjDestinatario) , "Informe o CNPJ do destinatário.");

            using (var dao = new DAL.DbCteDestinatario())
            {
                
                Validador.Validar(Validador.ValidarData(pDtInicioIntervalo), "Informe uma data inicial válida.");
                Validador.Validar(Validador.ValidarData(pDtFinalIntervalo), "Informe uma data final válida.");

                Validador.Validar(Convert.ToDateTime(pDtInicioIntervalo) <= Convert.ToDateTime(pDtFinalIntervalo), "A data inicial deve ser menor ou igual a data final.");

               
                return dao.Listar(pNuCnpjRemetente, pNuCnpjEmitente, pNuCnpjDestinatario,
                    pNuCnpjTomadorServico, pNuCnpjTomExpedidor, pNuCnpjTomRecebedor, pDtInicioIntervalo, pDtFinalIntervalo, pCdMunicipio);
            }
        }

    }
}
