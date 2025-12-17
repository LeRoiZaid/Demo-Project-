using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DemoDbContext _demoDbContext;

        public GenericRepo(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }
        public int Add(T item)
        {
            _demoDbContext.Add(item);
            return _demoDbContext.SaveChanges();
        }

        public int Delete(T item)
        {
            _demoDbContext.Remove(item);
            return _demoDbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _demoDbContext.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _demoDbContext.Set<T>().Find(Id);
        }

        public int Update(T item)
        {
            _demoDbContext.Update(item);
            return _demoDbContext.SaveChanges();
        }
    }
}
