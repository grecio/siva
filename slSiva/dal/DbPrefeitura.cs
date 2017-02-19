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
    public class DbPrefeitura : IDisposable
    {

        public IEnumerable<Prefeitura> Listar()
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<Prefeitura>("Select * from sig_prefeitura");
            }
        }

        public Prefeitura Selecionar(decimal SQ_PREFEITURA)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.QueryFirstOrDefault<Prefeitura>("Select * from sig_prefeitura Where SQ_PREFEITURA=:SQ_PREFEITURA ", new { SQ_PREFEITURA = SQ_PREFEITURA });
            }
        }

        public void Incluir(Prefeitura prefeitura)
        {

            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {

                cnn.Execute(@" INSERT INTO SIG_PREFEITURA(
                                                NM_PREFEITURA,
                                                NM_PREFEITO,
                                                NM_SEC_TRIBUTACAO,
                                                NM_CONTADOR,
                                                NM_LOGRADOURO,
                                                NU_NUMERO,
                                                TX_CONTATO,
                                                DT_INCLUSAO,
                                                NM_USUARIO_INCLUSAO,
                                                NU_HABITANTES,
                                                QT_EXTENSAO_TERRITORIAL,
                                                CD_MUNICIPIO)
                                                VALUES(
                                                :NM_PREFEITURA,
                                                :NM_PREFEITO,
                                                :NM_SEC_TRIBUTACAO,
                                                :NM_CONTADOR,
                                                :NM_LOGRADOURO,
                                                :NU_NUMERO,
                                                :TX_CONTATO,
                                                SYSDATE,
                                                USER,
                                                :NU_HABITANTES,
                                                :QT_EXTENSAO_TERRITORIAL, 
                                                :CD_MUNICIPIO)", prefeitura);
            }

        }

        public void Excluir(decimal SQ_PREFEITURA)
        {

            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                cnn.Execute(@"DELETE FROM SIG_PREFEITURA WHERE(SQ_PREFEITURA = :SQ_PREFEITURA)", new { SQ_PREFEITURA = SQ_PREFEITURA });
            }
        }

        public void Atualizar(Prefeitura prefeitura)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {


                cnn.Execute(@" UPDATE SIG_PREFEITURA SET 
                                                NM_PREFEITURA = :NM_PREFEITURA,
                                                NM_PREFEITO = :NM_PREFEITO,
                                                NM_SEC_TRIBUTACAO = :NM_SEC_TRIBUTACAO,
                                                NM_CONTADOR = :NM_CONTADOR,
                                                NM_LOGRADOURO = :NM_LOGRADOURO,
                                                TX_COMPLEMENTO = :TX_COMPLEMENTO,
                                                NU_NUMERO = :NU_NUMERO,
                                                TX_CONTATO = :TX_CONTATO,
                                                DT_ALTERACAO = SYSDATE,
                                                NM_USUARIO_ALTERACAO = USER,
                                                NU_HABITANTES = :NU_HABITANTES,
                                                QT_EXTENSAO_TERRITORIAL = :QT_EXTENSAO_TERRITORIAL,
                                                CD_MUNICIPIO = :CD_MUNICIPIO", prefeitura);
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

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DbPrefeitura() {
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
