using DBBroker.Engine;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbUsuario
    {

        public int EfetuarLogon(string login, string senha)
        {

            DBBrokerLive.ExecCmdSQL(cmdText: "SELECT * FROM sig_usuario WHERE(login = :login) AND(senha = :senha)",
                                    parameters: new List<DbParameter>() { new OracleParameter(":login", login), new OracleParameter(":senha", senha) });

            return 0;
        }

    }
}
