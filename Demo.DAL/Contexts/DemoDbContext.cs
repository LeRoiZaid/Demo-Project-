using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Contexts
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options): base(options)
        {
            
        }
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //       optionsBuilder.UseSqlServer("Server= .; Database=DemoDB;Trusted_Connection=true;");
    //    }
       public DbSet<Models.Department> Departments { get; set; }
    }
}
//MultipleActiveResultSets = true
