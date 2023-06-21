using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger.Core.EntityFramework
{
    public interface ISqlManager
    {
        SqlConnection OpenSqlConnection();
        SqlDataReader SqlQueryFunction(SqlConnection con, string query);
        void CloseSqlConnection(SqlConnection con);

    }
}
