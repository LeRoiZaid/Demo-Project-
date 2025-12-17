using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters long")]
        public string Name { get; set; }
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int? Age { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]

        public string Email { get; set; }
        //[RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number")]
        
        public int PhoneNumber { get; set; }
        [RegularExpression("^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",ErrorMessage ="Address Must Be Like 123-Street-City-Country")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; }= DateTime.Now;
        public string Position { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [InverseProperty("Employees")]
        public Department? Department { get; set; }
        
    }
}
