using ConsoleAppLogger.Core.EntityFramework;
using ConsoleAppLogger.DTO;
using ConsoleAppLogger.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleAppLogger.Managers
{
    public class UserManager
    {
        SqlManager _sqlManager = new SqlManager();
        public void Create(User user)
        {
            string query = @"INSERT INTO Users(NameSurname, Email, Password, PhoneNumber, CreatedDate, IsActive) VALUES("+
                user.UserNameSurname.ToString()+ ", " +
                user.Email.ToString()+ ", " +
                user.Password.ToString()+ ", " +
                user.PhoneNumber.ToString()+ ", " +
                user.CreatedDate.ToString()+ ", " +
                user.IsActive.ToString()+ ", " +
                "); ";
            SqlConnection con = _sqlManager.OpenSqlConnection();
            _sqlManager.SqlQueryFunction(con, query);
            _sqlManager.CloseSqlConnection(con);
        }
        public List<UserDTO> GetUser()
        {
            string query = @"SELECT NameSurname, Email, Password, PhoneNumber, CreatedDate From Users Where IsActive = 1";
            List<UserDTO> users = new List<UserDTO>();
            SqlConnection con = _sqlManager.OpenSqlConnection();
            SqlDataReader reader = _sqlManager.SqlQueryFunction(con, query);
            while (reader.Read())
            {
                var _user = new UserDTO()
                {
                    UserNameSurname = reader["NameSurname"].ToString(),
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    CreateDateString = reader["CreatedDate"].ToString().Split(' ')[0]
                };
                users.Add(_user);
            }
            _sqlManager.CloseSqlConnection(con);
            return users;
        }
        public void LogControl(bool isAdmin, string email, string password, Form formLogin)
        {

            string query = @"SELECT * From Users where Email='" +
                email + "' and Password = '" +
                password + "' and IsActive = 1 ";
            if (isAdmin) query += "and IsAdmin = 1";
            else query += "and IsAdmin = 0";
            SqlConnection con = _sqlManager.OpenSqlConnection();
            SqlDataReader reader = _sqlManager.SqlQueryFunction(con, query);
            if(reader.Read())
            {
                Form1.senderNameSurname = reader["NameSurname"].ToString();
                if (isAdmin) Form1.senderIsAdmin = true;
                HomePage homePage = new HomePage();
                formLogin.Hide();
                homePage.ShowDialog();
            }
            else MessageBox.Show("Mail or password incorrect!", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            _sqlManager.CloseSqlConnection(con);

        }
    }
}
