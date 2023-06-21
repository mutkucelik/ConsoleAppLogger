using ConsoleAppLogger.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger.Repository
{
    public class GenericRepository<T> : IGenericInterface<T> where T : class
    {
        private readonly ISqlManager _sqlManager;
        public GenericRepository(ISqlManager sqlManager)
        {
            _sqlManager = sqlManager;
        }
        public void Create(T t)
        {
            SqlConnection con = _sqlManager.OpenSqlConnection();
        }

        public void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T t, int id)
        {
            throw new NotImplementedException();
        }
    }
}
