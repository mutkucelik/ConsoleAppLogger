using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger.Repository
{
    public interface IGenericInterface<T> where T : class
    {
        void Create(T t);
        void Update(T t, int id);
        void Delete(T t);
        List<T> GetAll();
        T GetById(int id);
    }
}
