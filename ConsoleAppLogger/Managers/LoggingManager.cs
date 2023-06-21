using ConsoleAppLogger.Core.EntityFramework;
using ConsoleAppLogger.DTO;
using ConsoleAppLogger.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger.Managers
{
    public class LoggingManager
    {
        SqlManager _sqlManager = new SqlManager();
        public void Create(Logging logging)
        {
            string query = @"INSERT INTO Users(Description,CorporateId,LogTypeId,UserId, CreatedDate, IsActive) VALUES(" +
                logging.Description.ToString() + ", " +
                logging.CorporateId.ToString() + ", " +
                logging.LogTypeId.ToString() + ", " +
                logging.UserId.ToString() + ", " +
                logging.CreatedDate.ToString() + ", " +
                logging.IsActive.ToString() + ", " +
                "); ";
            SqlConnection con = _sqlManager.OpenSqlConnection();
            _sqlManager.SqlQueryFunction(con, query);
            _sqlManager.CloseSqlConnection(con);
        }
        public List<LoggingDTO> GetLogging()
        {
            string query = @"SELECT 
                lg.Description
                ,lgty.LogType
                ,us.NameSurname
                ,com.CompanyName
                ,lg.CreateDate
                From Logging lg
                Inner Join Companies com on com.Id = lg.CompanyId
                Inner Join Users us on us.Id = lg.UserId
                Inner Join LogType lgty on lgty.Id = lg.LogTypeId
                Where lg.IsActive = 1";
            List<LoggingDTO> loggings = new List<LoggingDTO>();
            SqlConnection con = _sqlManager.OpenSqlConnection();
            SqlDataReader reader = _sqlManager.SqlQueryFunction(con, query);
            while (reader.Read())
            {
                var _logging = new LoggingDTO()
                {
                    Description = reader["Description"].ToString(),
                    LogType = reader["LogType"].ToString(),
                    NameSurname = reader["NameSurname"].ToString(),
                    CompanyName = reader["CompanyName"].ToString(),                   
                    CreateDate = reader["CreateDate"].ToString().Split(' ')[0]
                };
                loggings.Add(_logging);
            }
            _sqlManager.CloseSqlConnection(con);
            return loggings;
        }
    }
}
