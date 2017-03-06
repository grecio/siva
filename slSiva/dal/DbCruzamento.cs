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
    public class DbCruzamento : IDisposable
    {

        public IEnumerable<CruzamentoTipo> RetornarTipoCruzamento()
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<CruzamentoTipo>("SELECT t.CD_CRUZAMENTO, t.DC_CRUZAMENTO, t.FG_CRITICAR, t.FG_ISENCAO FROM crz_tipo_cruzamento t ORDER BY t.DC_CRUZAMENTO");
            }
        }

        public IEnumerable<CruzamentoCabecalho> RetornarCabecalhoCruzamento()
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<CruzamentoCabecalho>("select * from ctl_controle_processo");
            }
        }

        public void ExecutarCruzamento(decimal codigoMunicipio, int tipoCruzamento, int anoInicial, int anoFinal)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {

                var parameters = new OracleDynamicParameters();

                parameters.Add("pCdMunicipio", codigoMunicipio);
                parameters.Add("pNuCritica", tipoCruzamento);
                parameters.Add("pAnoInicial", anoInicial);
                parameters.Add("pAnoFinal", anoFinal);
                parameters.Add("pNuProcesso", null, OracleDbType.Decimal, ParameterDirection.Output);
                parameters.Add("pErro", null, OracleDbType.Varchar2, ParameterDirection.Output, 1000);
                
                cnn.Execute("ADM_OBJETOS.CRZPKG_GERENCIA_CRUZAMENTO.SP_PROCESSA_CRUZAMENTO", param: parameters, commandType: CommandType.StoredProcedure);
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
        // ~DbMunicipio() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
