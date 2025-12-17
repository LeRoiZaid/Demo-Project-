using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using Demo.BLL.Interfaces;

namespace Demo_Project.Controllers
{
    public class EmployeeController : Controller
    {
       
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepo employeeRepo,IDepartmentRepository departmentRepository)
        {
            
           _employeeRepo = employeeRepo;
           _departmentRepository = departmentRepository;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View( _employeeRepo.GetAll());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepo.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList( _departmentRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
               _employeeRepo.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepo.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Email,PhoneNumber,Address,Salary,IsActive,HireDate,CreationDate,Position")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _employeeRepo.Update(employee);
                
              
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepo.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = _employeeRepo.GetById(id);
            if (employee != null)
            {
                _employeeRepo.Delete(employee);
            }

           
            return RedirectToAction(nameof(Index));
        }

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.Id == id);
        //}
    }
}
