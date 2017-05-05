using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSample.DAL;
using MvcSample.Models;

namespace MvcSample.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DAL_Employee _employeedbContext; 
        public EmployeeController()
        {
            _employeedbContext = new DAL_Employee();
        }

        // GET: Employee
        public ActionResult Master_Employee()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(Employee employee)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    _employeedbContext.Add(employee);
                    ViewData["Message"] = "Added Successfully";
                }
            }
            catch (Exception ex)
            {

                ViewData["Message"] = ex.Message;
            }

            return View("Master_Employee", employee);
        }

        [HttpGet]
        public ActionResult Details()
        {
            var _employeeList = new EmployeesList();
            try
            {
                _employeeList.Employees = _employeedbContext.GetAllData();

                if(_employeeList == null)
                {
                    ViewData["Message"] = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View("Details", _employeeList);
        }

        [Route("Employee/Delete/{id? : int}")]
        public ActionResult Delete(int? id)
        {
            try
            {
                if(id == null)
                {
                    ViewData["Message"] = "Please Specify the Employee code";
                }
                else
                {
                    var employee = new Employee();
                    employee = _employeedbContext.GetAllData().Single(e => e.EmployeeCode == id);
                    _employeedbContext.Delete(employee);
                    ViewData["Message"] = "Deleted Successfully";
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("Details");
        }

        [Route("Employee/Edit/{id? : int}")]
        public ActionResult Edit(int id)
        {
            var employee = new Employee();
            try
            {
                employee = _employeedbContext.GetAllData().Single(e => e.EmployeeCode == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                _employeedbContext.Update(employee);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }

            return RedirectToAction("Details");
        }
    }
}