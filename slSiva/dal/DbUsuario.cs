using Dapper;
using Dominio;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class DbUsuario : IDisposable
    {
        public IEnumerable<Usuario> Listar()
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<Usuario>("Select * from sig_usuario");
            }
        }

        public Usuario EfetuarLogon(string login, string senha)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {            
                return cnn.QueryFirstOrDefault<Usuario>("Select * from sig_usuario Where login=:login and senha = :senha", new { login = login, senha = senha });                
            }
        }

        public Usuario Selecionar(decimal SQ_USUARIO)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.QueryFirstOrDefault<Usuario>("Select * from sig_usuario Where SQ_USUARIO=:SQ_USUARIO ", new { SQ_USUARIO = SQ_USUARIO });
            }
        }

        public void AtualizarSenha(string senha, decimal SQ_USUARIO)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                cnn.Execute(@"UPDATE SIG_USUARIO SET Senha = :Senha WHERE(SQ_USUARIO = :SQ_USUARIO)", new { Senha = senha, SQ_USUARIO = SQ_USUARIO });                
            }            
        }

        public void Excluir(decimal SQ_USUARIO)
        {

            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                cnn.Execute(@"DELETE FROM SIG_USUARIO WHERE(SQ_USUARIO = :SQ_USUARIO)", new { SQ_USUARIO = SQ_USUARIO });
            }
        }

        public void Incluir(Usuario usuario)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                cnn.Execute(@"INSERT INTO sig_usuario (NM_USUARIO, LOGIN, SENHA, DT_INCLUSAO, NM_USUARIO_INCLUSAO) VALUES(:NM_USUARIO, :LOGIN, :SENHA, SYSDATE, USER)", usuario);
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
        // ~DbUsuario() {
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
