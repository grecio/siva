﻿using CommonFrameWork;
using Dapper;
using Dominio;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbCteDestinatario : IDisposable
    {
        public IEnumerable<CteDestinatario> Listar(string pNuCnpjRemetente, string pNuCnpjEmitente, string pNuCnpjDestinatario,
                                            string pNuCnpjTomadorServico, string pNuCnpjTomExpedidor, string pNuCnpjTomRecebedor,
                                            string pDtInicioIntervalo, string pDtFinalIntervalo, decimal? pCdMunicipio)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                

                var parameters = new OracleDynamicParameters();

                parameters.Add("pNuCnpjRemetente", Formatador.SoNumero(pNuCnpjRemetente));
                parameters.Add("pNuCnpjEmitente", Formatador.SoNumero(pNuCnpjEmitente));
                parameters.Add("pNuCnpjDestinatario", Formatador.SoNumero(pNuCnpjDestinatario));
                parameters.Add("pNuCnpjTomadorServico", Formatador.SoNumero(pNuCnpjTomadorServico));
                parameters.Add("pNuCnpjTomExpedidor", Formatador.SoNumero(pNuCnpjTomExpedidor));
                parameters.Add("pNuCnpjTomRecebedor", Formatador.SoNumero(pNuCnpjTomRecebedor));

                parameters.Add("pDtInicioIntervalo", Convert.ToDateTime(pDtInicioIntervalo).ToString("yyyyMMdd"));

                parameters.Add("pDtFinalIntervalo", Convert.ToDateTime(pDtFinalIntervalo).ToString("yyyyMMdd"));
                
                parameters.Add("pCdMunicipio", pCdMunicipio);


                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                return cnn.Query<CteDestinatario>("ADM_OBJETOS.CTEPKG_CONHECIMENTO_TRANSPORTE.SP_CONSULTA_CTE_DEST", param: parameters, commandType: CommandType.StoredProcedure);                
            }
        }     

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    GC.Collect();
                }

                disposedValue = true;
            }
        }
                
        public void Dispose()
        {            
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
