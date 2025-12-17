using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        private readonly DemoDbContext _demoDbContext;

        public EmployeeRepo(DemoDbContext demoDbContext):base(demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        public IQueryable<Employee> GetEmployeesWithAddress(string address)
        {
            return _demoDbContext.Employees.Where(e => e.Address.Contains(address));
        }
        //private readonly DemoDbContext _demoDbContext;

        //public EmployeeRepo(DemoDbContext demoDbContext)
        //{
        //    _demoDbContext = demoDbContext;
        //}
        //public int Add(Employee employee)
        //{
        //    _demoDbContext.Employees.Add(employee);
        //    return _demoDbContext.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    _demoDbContext.Employees.Remove(employee);
        //    return _demoDbContext.SaveChanges();
        //}

        //public IEnumerable<Employee> GetAll()
        //{
        //    return _demoDbContext.Employees.ToList();
        //}

        //public Employee GetById(int Id)
        //{
        //    return _demoDbContext.Employees.Find(Id);
        //}

        //public int Update(Employee employee)
        //{
        //    _demoDbContext.Employees.Update(employee);
        //    return _demoDbContext.SaveChanges();
        //}
    }
}
