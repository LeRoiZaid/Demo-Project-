using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepo<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        int Add(T employee);
        int Update(T employee);
        int Delete(T employee);
    }
}
