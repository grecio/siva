using CommonFrameWork;
using Dapper;
using Dominio;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbResumoFinanceiro : IDisposable
    {
        public IEnumerable<ResumoFinanceiro> RetornaResumoFinanceiro(long? codigoMunicipio, string Cnpj, int AnoInicial, int AnoFinal)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                var parameters = new OracleDynamicParameters();

                parameters.Add("pCdMunicipio", codigoMunicipio);
                parameters.Add("pNuCnpj", Formatador.SoNumero(Cnpj));
                parameters.Add("pAnoInicio", AnoInicial);
                parameters.Add("pAnoFinal", AnoFinal);
                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output, size: 500);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
                                
                var resumoFinanceiroList =  cnn.Query("ADM_OBJETOS.VADPKG_CALCULA_VLR_ADICIONADO.SP_CONSULTA_RECEITA_PERIODO", param: parameters, commandType: CommandType.StoredProcedure)
                     .Select(x =>
                     {
                         var result = new ResumoFinanceiro { NM_RAZAO_SOCIAL = x.NM_RAZAO_SOCIAL, NU_CNPJ_FILIAL = x.NU_CNPJ_FILIAL, TP_RECEITA = x.TP_RECEITA };

                         int i = 0;

                         foreach (dynamic element in x)
                         {
                             int.TryParse(element.Key, out i);

                             if (i > 0)
                                 result.ANOS_RECEITA.Add(element);

                         }
                         return result;
                     }).ToList();

                return resumoFinanceiroList;
            }
        }

        public IEnumerable<ResumoFinanceiroPorTipo> RetornaResumoFinanceiroPorTipo(long? codigoMunicipio, string Cnpj, int AnoInicial, int AnoFinal)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                var parameters = new OracleDynamicParameters();

                parameters.Add("pCdMunicipio", codigoMunicipio);
                parameters.Add("pNuCnpj", Formatador.SoNumero(Cnpj));
                parameters.Add("pAnoInicio", AnoInicial);
                parameters.Add("pAnoFinal", AnoFinal);
                parameters.Add("pErro", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output, size: 500);
                parameters.Add("pCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                return cnn.Query<ResumoFinanceiroPorTipo>("ADM_OBJETOS.VADPKG_CALCULA_VLR_ADICIONADO.SP_CONSULTA_TIPO_RECEITA", param: parameters, commandType: CommandType.StoredProcedure);
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
