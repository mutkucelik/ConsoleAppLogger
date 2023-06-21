using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger.Core.EntityFramework
{
    public class SqlManager : ISqlManager
    {
        public SqlConnection OpenSqlConnection()
        {
            string str = @"Server=DESKTOP-GHRCG23;Database=LogsProject;Persist Security Info=True;User ID=sa;Password=1";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            return con;
        }
        public SqlDataReader SqlQueryFunction(SqlConnection con, string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void CloseSqlConnection(SqlConnection con)
        {
            con.Close();
        }
    }
}
