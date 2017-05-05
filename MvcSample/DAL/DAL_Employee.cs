using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcSample.Models;

namespace MvcSample.DAL
{
    public abstract class EmployeeManager
    {
        public EmployeeManager()
        {

        }

        public abstract void Add(Employee employee);
        public abstract void Update(Employee employee);
        public abstract void Delete(Employee employee);
        public abstract List<Employee> GetAllData();
    }
    public class DAL_Employee :  EmployeeManager
    {
        EmployeeDbContext context = new EmployeeDbContext();

        public override void Add(Employee employee)
        {
            try
            {
                context.Employee.Add(employee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }      

        public override void Delete(Employee employee)
        {
            try
            {
                context.Employee.Remove(employee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public override List<Employee> GetAllData()
        {
            var employeeList = new List<Employee>();
            try
            {
                employeeList = context.Employee.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employeeList;
        }

        public override void Update(Employee employee)
        {
            try
            {
                Employee _employee = new Employee();
                _employee = context.Employee.Single(e => e.EmployeeCode == employee.EmployeeCode);
                _employee.EmployeeName = employee.EmployeeName;
                _employee.Category = employee.Category;
                _employee.Dob = employee.Dob;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}