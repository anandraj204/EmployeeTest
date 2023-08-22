using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeTest.Models;
using EmployeeTest.Repository;

namespace EmployeeTest.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

       
        public ActionResult Index()
        {
            return View(_employeeRepository.GetAll());
        }

        
        public ActionResult Details(int id)
        {     
            var details = _employeeRepository.Details(id);

            return PartialView("_Details", details);
        }
        
        public IActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FirstName,LastName,City,Zip,CreatedDate")] EmployeeTest.Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,City,Zip,CreatedDate")] EmployeeTest.Models.Employee employee)
        {
            var employee = _employeeRepository.Edit(employee);
            return View(employee);
        }

       
        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
