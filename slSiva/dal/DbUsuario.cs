using CommonFrameWork;
using Dapper;
using Dominio;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Transactions;

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

        public IEnumerable<decimal> RetornaPrefeiturasPorUsuario(decimal SQ_USUARIO)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<decimal>("select SQ_PREFEITURA from SIG_USUARIO_PREFEITURA Where SQ_USUARIO=:SQ_USUARIO ", new { SQ_USUARIO = SQ_USUARIO });
            }


        }

        public void AtualizarSenha(string senha, decimal SQ_USUARIO)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                cnn.Execute(@"UPDATE SIG_USUARIO SET Senha = :Senha WHERE(SQ_USUARIO = :SQ_USUARIO)", new { Senha = senha, SQ_USUARIO = SQ_USUARIO });
            }
        }

        public void VincularPrefeituras(UsuarioPrefeitura usuarioPrefeitura)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                using (OracleConnection dbConnection = new OracleConnection(Properties.Settings.Default.ConnectionString))
                {
                    try
                    {
                        dbConnection.Execute(@"DELETE FROM SIG_USUARIO_PREFEITURA WHERE SQ_USUARIO = :SQ_USUARIO", new { SQ_USUARIO = usuarioPrefeitura.Usuario.SQ_USUARIO });


                        foreach (var prefeitura in usuarioPrefeitura.PrefeituraList)
                        {
                            dbConnection.Execute(@"INSERT INTO SIG_USUARIO_PREFEITURA (SQ_USUARIO, SQ_PREFEITURA) VALUES (:SQ_USUARIO, :SQ_PREFEITURA)", new { usuarioPrefeitura.Usuario.SQ_USUARIO, prefeitura.SQ_PREFEITURA });
                        }

                        scope.Complete();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }
            }

        }

        public void Excluir(decimal seqUsuario)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                using (OracleConnection dbConnection = new OracleConnection(Properties.Settings.Default.ConnectionString))
                {
                    try
                    {
                        dbConnection.Execute(@"DELETE FROM SIG_USUARIO_PREFEITURA WHERE SQ_USUARIO = :SQ_USUARIO", new { SQ_USUARIO = seqUsuario });
                        
                        dbConnection.Execute(@"DELETE FROM SIG_USUARIO WHERE(SQ_USUARIO = :SQ_USUARIO)", new { SQ_USUARIO = seqUsuario });

                        scope.Complete();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }
            }        
        }

        public void Incluir(Usuario usuario)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                using (OracleConnection dbConnection = new OracleConnection(Properties.Settings.Default.ConnectionString))
                {
                    try
                    {

                        usuario.SQ_USUARIO = dbConnection.ExecuteScalar<decimal>(@"SELECT SQ_USUARIO FROM SIG_USUARIO WHERE LOGIN = :LOGIN ", new { usuario.LOGIN });

                        Validador.Validar(!(usuario.SQ_USUARIO > 0), "Já existe um usuário com o login informado");

                        dbConnection.Execute(@"INSERT INTO sig_usuario (NM_USUARIO, LOGIN, SENHA, DT_INCLUSAO, NM_USUARIO_INCLUSAO, ADMINISTRADOR) VALUES(:NM_USUARIO, :LOGIN, :SENHA, SYSDATE, USER, :ADMINISTRADOR)", usuario);

                        if (usuario.ADMINISTRADOR == "S")
                        {

                            usuario.SQ_USUARIO = dbConnection.ExecuteScalar<decimal>(@"SELECT SQ_USUARIO FROM SIG_USUARIO WHERE LOGIN = :LOGIN AND SENHA = :SENHA", new { usuario.LOGIN, usuario.SENHA });

                            dbConnection.Execute(@"DELETE FROM SIG_USUARIO_PREFEITURA WHERE SQ_USUARIO = :SQ_USUARIO", new { usuario.SQ_USUARIO });

                            var prefeituras = dbConnection.Query<Prefeitura>("SELECT * FROM SIG_PREFEITURA", null).AsList();


                            foreach (var prefeitura in prefeituras)
                            {
                                dbConnection.Execute(@"INSERT INTO SIG_USUARIO_PREFEITURA (SQ_USUARIO, SQ_PREFEITURA) VALUES (:SQ_USUARIO, :SQ_PREFEITURA)", new { usuario.SQ_USUARIO, prefeitura.SQ_PREFEITURA });
                            }

                        }

                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
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
