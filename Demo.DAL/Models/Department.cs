using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage =" Name") ]
        [MaxLength(50, ErrorMessage =" Name max length is 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = " Code is required")]
        public string Code { get; set; }
        public DateTime DataOfCreation { get; set; }
        [InverseProperty("Department")]
        public ICollection<Employee>? Employees { get; set; }
    }
}
