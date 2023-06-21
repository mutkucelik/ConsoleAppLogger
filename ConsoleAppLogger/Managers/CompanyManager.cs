using ConsoleAppLogger.Core.EntityFramework;
using ConsoleAppLogger.DTO;
using ConsoleAppLogger.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleAppLogger.Managers
{
    public class CompanyManager
    {
        SqlManager _sqlManager = new SqlManager();
        public void Create(Company company)
        {
            string query = @"INSERT INTO Users(CompanyName,Sector,CompanyPhone, CreatedDate, IsActive) VALUES(" +
                company.CompanyName.ToString() + ", " +
                company.Sector.ToString() + ", " +
                company.CompanyPhone.ToString() + ", " +
                company.CreatedDate.ToString() + ", " +
                company.IsActive.ToString() + ", " +
                "); ";
            SqlConnection con = _sqlManager.OpenSqlConnection();
            _sqlManager.SqlQueryFunction(con, query);
            _sqlManager.CloseSqlConnection(con);
        }
        public List<CompanyDTO> GetCompany()
        {
            string query = @"SELECT CompanyName,Sector,CompanyPhone, CreatedDate From Companies Where IsActive = 1";
            List<CompanyDTO> company = new List<CompanyDTO>();
            SqlConnection con = _sqlManager.OpenSqlConnection();
            SqlDataReader reader = _sqlManager.SqlQueryFunction(con, query);
            while (reader.Read())
            {
                var _company = new CompanyDTO()
                {
                    CompanyName = reader["CompanyName"].ToString(),
                    Sector = reader["Sector"].ToString(),
                    CompanyPhone = reader["CompanyPhone"].ToString(),
                    CreateDateString = reader["CreatedDate"].ToString().Split(' ')[0],
                };
                company.Add(_company);
            }
            _sqlManager.CloseSqlConnection(con);
            return company;
        }
    }
}
