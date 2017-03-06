using Dapper;
using Dominio;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbMunicipio : IDisposable
    {

        public IEnumerable<Municipio> RetornaMunicipio()
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<Municipio>("select m.CD_MUNICIPIO_RFB, m.NM_MUNICIPIO_RFB from ADM_OBJETOS.CAD_MUNICIPIO_RFB m where m.SG_UF_MUNICIPIO1 = 'RN' order by m.NM_MUNICIPIO_RFB ");
            }
        }

        public IEnumerable<Municipio> RetornaMunicipio(Usuario usuario)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {

                var sql = new StringBuilder();

                sql.AppendLine("select m.CD_MUNICIPIO_RFB, m.NM_MUNICIPIO_RFB from ADM_OBJETOS.CAD_MUNICIPIO_RFB m where m.SG_UF_MUNICIPIO1 = 'RN' AND ");
                sql.AppendLine("m.CD_MUNICIPIO_RFB IN( ");
                sql.AppendLine("select p.CD_MUNICIPIO from ADM_OBJETOS.SIG_PREFEITURA p ");
                sql.AppendLine("inner join ADM_OBJETOS.SIG_USUARIO_PREFEITURA up on up.SQ_PREFEITURA = p.SQ_PREFEITURA WHERE up.SQ_USUARIO = {0})");

                return cnn.Query<Municipio>(string.Format(sql.ToString(), usuario.SQ_USUARIO));
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
