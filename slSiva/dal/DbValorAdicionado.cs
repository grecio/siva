using Dapper;
using Dominio;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DbValorAdicionado : IDisposable
    {

        public decimal ExecutarProcessamento(decimal codigoMunicipio, string tipoCalculo, int anoBase)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {


                var parameters = new OracleDynamicParameters();

                parameters.Add("pAnoBase", anoBase);
                parameters.Add("pTpCalculo", tipoCalculo);
                parameters.Add("pCdMunicipio", codigoMunicipio);
                parameters.Add("pNuProcesso", null, OracleDbType.Decimal, ParameterDirection.Output);
                parameters.Add("pResultado", null, OracleDbType.Varchar2, ParameterDirection.Output, 5000);

                cnn.Execute("ADM_OBJETOS.VADPKG_CALCULA_VLR_ADICIONADO.SP_CALCULA_VAD", param: parameters, commandType: CommandType.StoredProcedure);

                return Convert.ToDecimal(parameters.Get<OracleDecimal>("pNuProcesso").ToString());
            }
        }

        public IEnumerable<ValorAdicionadoCabecalho> RetornaCabecalhoValorAdicionado()
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<ValorAdicionadoCabecalho>("select nu_processo, cd_processo, st_processo, dt_inicio_execucao,  dt_final_execucao,  dc_parametros from   ctl_controle_processo cp where cp.tp_processo = '2' order by nu_processo desc");
            }
        }


        public IEnumerable<ValorAdicionadoDetalhamento> RetornarDetalhamentoValorAdicionado(decimal numeroProcesso)
        {
            using (OracleConnection cnn = new OracleConnection(Properties.Settings.Default.ConnectionString))
            {
                return cnn.Query<ValorAdicionadoDetalhamento>(string.Format("select t.*, m.NM_MUNICIPIO_RFB " +
                            " from   adm_objetos.vad_consulta_processado t " +
                            "    inner join ADM_OBJETOS.CAD_MUNICIPIO_RFB m on m.CD_MUNICIPIO_RFB = t.CD_MUNICIPIO " +
                            "        where t.nu_processo = {0} " +
                            " order by t.TP_INFORMACAO ", numeroProcesso));

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
        // ~DbValorAdicionado() {
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
