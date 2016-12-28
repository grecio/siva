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
    public class DbInformativoFiscal : IDisposable
    {
        public IEnumerable<Referencia.InformativoFiscal> RetornarReferenciaPorInscricao(string ie)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("pNuInscricao", ie);
                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                return cnn.Query<Referencia.InformativoFiscal>("ADM_OBJETOS.IFFPKG_INFORMATIVO_FISCAL.SP_IFF_RETORNA_REFERENCIA", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public IEnumerable<ReferenciaInformativoFiscal> RetornaInformativoFiscalPorInscricaoReferencia(string ie, decimal? referencia)
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

                return cnn.Query<ReferenciaInformativoFiscal>("ADM_OBJETOS.IFFPKG_INFORMATIVO_FISCAL.SP_CONSULTA_INFORM_FISCAL", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public InformativoFiscal RetornaInformativoFiscal(string ie, decimal referencia)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("pNuInscricao", ie);
                parameters.Add("pReferencia", referencia);
                
                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                return cnn.QueryFirst<InformativoFiscal>("ADM_OBJETOS.IFFPKG_INFORMATIVO_FISCAL.SP_CONSULTA_INFORM_FISCAL", param: parameters, commandType: CommandType.StoredProcedure);
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
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DbInformativoFiscal() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
