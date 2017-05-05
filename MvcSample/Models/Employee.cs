using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace MvcSample.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [Display(Name = "Employee Code")]
        public int EmployeeCode { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set;}
        [MaxLength(12)]
        [Display(Name ="Category Name")]
        public string Category { get; set; }
        [Display(Name ="Date of Birth")]
        public DateTime? Dob { get; set; }

        
    }
    public class EmployeesList
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }

}