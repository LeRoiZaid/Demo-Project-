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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DemoDbContext _dbcontext;
        public DepartmentRepository(DemoDbContext dbContext) //Ask for dbcontext object from DI Container(CLR)
        {
            #region False Way To Connect To DB
            //// _dbcontext = new DemoDbContext();
            //every time new object of repository is created new object of dbcontext is created it's False Way xxxxx
            //Dependency Injection is the best way to handle dbcontext object using DI container CLR will manage the lifetime of dbcontext object
            //Scoped Lifetime is the best lifetime for dbcontext object
            //In ASP.NET Core we can register dbcontext in the service container in the Program.cs file
            //services.AddDbContext<DemoDbContext>(options => options.UseSqlServer("Server= .; Database=DemoDB;Trusted_Connection=true;"));
            //Then we can inject dbcontext in the repository constructor 
            #endregion
            _dbcontext = dbContext;
        }
        
        
        
        public int Add(Department department)
        {
            _dbcontext.Departments.Add(department);
            return _dbcontext.SaveChanges();

        }

        public int Delete(Department department)
        {
            _dbcontext.Remove(department);
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
          // _dbcontext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
              return _dbcontext.Departments.ToList();
        }

        public Department GetById(int Id)
        {
            _dbcontext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;


            //var depart = _dbcontext.Departments.Local.Where(d => d.Id == Id).FirstOrDefault();
            //if (depart == null)
            //{
            //    depart = _dbcontext.Departments.Where(d => d.Id == Id).FirstOrDefault();
            //}
            var depart = _dbcontext.Departments.Find(Id);

            return depart;
            
           
        }

        public int Update(Department department)
        {
                _dbcontext.Update(department);
                return _dbcontext.SaveChanges();
        }
    }
}
