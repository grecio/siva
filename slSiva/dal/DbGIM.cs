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
    public class DbGIM : IDisposable
    {
        public IEnumerable<Referencia.GIM> RetornarReferenciaPorInscricao(string ie)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("pNuInscricao", ie);
                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                return cnn.Query<Referencia.GIM>("ADM_OBJETOS.GIMPKG_GUIA_INFORMATIVA_MENSAL.SP_GIM_RETORNA_REFERENCIA", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<GIMReferencia> RetornaGIMPorInscricaoReferencia(string ie, decimal? referencia)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("pNuInscricao", ie);
                if (referencia.HasValue)
                {
                    parameters.Add("pReferencia", referencia.Value);
                }

                else
                {
                    parameters.Add("pReferencia", null);
                }

                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                return cnn.Query<GIMReferencia>("ADM_OBJETOS.GIMPKG_GUIA_INFORMATIVA_MENSAL.SP_CONSULTA_GUIA_MENSAL", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public GIM RetornaConsultaGuiaMensal(string ie, decimal referencia)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("pNuInscricao", ie);
                parameters.Add("pReferencia", referencia);
                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                return cnn.QueryFirst<GIM>("ADM_OBJETOS.GIMPKG_GUIA_INFORMATIVA_MENSAL.SP_CONSULTA_GUIA_MENSAL", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<GIMDetalhe> RetornaConsultaGuiaMensalDetalhe(string ie, decimal referencia)
        {



            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("pNuInscricao", ie);

                if (referencia == 0)
                {
                    parameters.Add("pReferencia", null);
                }
                else
                {
                    parameters.Add("pReferencia", referencia);
                }
                
                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                return cnn.Query<GIMDetalhe>("ADM_OBJETOS.GIMPKG_GUIA_INFORMATIVA_MENSAL.SP_CONSULTA_GUIA_MENSAL_DET", param: parameters, commandType: CommandType.StoredProcedure);
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
