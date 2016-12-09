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
    public class DbContador : IDisposable
    {
        public IEnumerable<Contador> Listar()
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<Contador>("Select * from CAD_CONTADOR");
            }
        }

        public Contador Selecionar(decimal SQ_CONTADOR)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.QueryFirstOrDefault<Contador>("Select * from CAD_CONTADOR Where SQ_CONTADOR=:SQ_CONTADOR ", new { SQ_CONTADOR = SQ_CONTADOR });
            }
        }

        public IEnumerable<Contribuinte> RetornaContribuintePorContador(decimal SQ_CONTADOR)
        { 
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<Contribuinte>(@"SELECT CM.* FROM ADM_OBJETOS.CAD_CONTRIBUINTE_MUNICIPAL CM
                                                    INNER JOIN ADM_OBJETOS.CAD_CONTADOR_CONTRIBUINTE CC ON CC.SQ_CONTRIBUINTE = CM.SQ_CONTRIBUINTE
                                                WHERE CC.SQ_CONTADOR = :SQ_CONTADOR", new { SQ_CONTADOR = SQ_CONTADOR });
            }
        }

        public void Incluir(Contador contador)
        {
            using (OracleConnection dbConnection = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                dbConnection.Open();

                using (var trn = dbConnection.BeginTransaction())
                {
                    try
                    {

                        dbConnection.Execute(@"INSERT INTO 
                                                CAD_CONTADOR 
                                                    (NU_CRC, 
                                                    NM_CONTADOR, 
                                                    NM_LOGRADOURO,
                                                    NU_LOGRADOURO, 
                                                    NM_COMPLEMENTO, 
                                                    NU_CEP, 
                                                    NM_BAIRRO, 
                                                    NU_TELEFONE, 
                                                    NM_EMAIL_COMERCIAL) 
                                                VALUES     
                                                    (:NU_CRC, 
                                                     :NM_CONTADOR, 
                                                     :NM_LOGRADOURO, 
                                                     :NU_LOGRADOURO,
                                                     :NM_COMPLEMENTO, 
                                                     :NU_CEP, 
                                                     :NM_BAIRRO, 
                                                     :NU_TELEFONE, 
                                                     :NM_EMAIL_COMERCIAL)", contador, trn);

                        trn.Commit();

                    }
                    catch
                    {
                        trn.Rollback();

                        throw;
                    }
                }

            }
        }

        public void Atualizar(Contador contador)
        {
            using (OracleConnection dbConnection = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                dbConnection.Open();

                using (var trn = dbConnection.BeginTransaction())
                {
                    try
                    {
                        dbConnection.Execute(@"
                                UPDATE CAD_CONTADOR SET
                                NU_CRC = :NU_CRC,
                                NM_CONTADOR = :NM_CONTADOR
                                NM_LOGRADOURO = :NM_LOGRADOURO,
                                NU_LOGRADOURO = :NU_LOGRADOURO,
                                NM_COMPLEMENTO = :NM_COMPLEMENTO,
                                NU_CEP = :NU_CEP,
                                NM_BAIRRO = :NM_BAIRRO,
                                NU_TELEFONE = :NU_TELEFONE,
                                NM_EMAIL_COMERCIAL : NM_EMAIL_COMERCIAL
                                WHERE SQ_CONTADOR = :SQ_CONTADOR", contador, trn);

                        trn.Commit();
                    }
                    catch 
                    {
                        trn.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Excluir(decimal SQ_CONTADOR)
        {

            using (OracleConnection dbConnection = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                dbConnection.Open();

                using (var trn = dbConnection.BeginTransaction())
                {
                    try
                    {
                        dbConnection.Execute(@"DELETE FROM CAD_CONTADOR_CONTRIBUINTE WHERE SQ_CONTADOR = :SQ_CONTADOR", new { SQ_CONTADOR = SQ_CONTADOR }, trn);


                        dbConnection.Execute(@"DELETE FROM CAD_CONTADOR WHERE SQ_CONTADOR = :SQ_CONTADOR", new { SQ_CONTADOR = SQ_CONTADOR }, trn);                        

                        trn.Commit();

                    }
                    catch (Exception e)
                    {

                        trn.Rollback();

                        throw e;
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
