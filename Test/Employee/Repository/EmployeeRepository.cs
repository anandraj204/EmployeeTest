using EmployeeTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace EmployeeTest.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;
        public EmployeeRepository(EmployeeDbContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<EmployeeTest.Models.Employee> GetAll()
        {  
            return _context.Employees.ToList();
        }
        public EmployeeTest.Models.Employee Create(EmployeeTest.Models.Employee employee)
        {
            if (employee == null)
            {
                throw new ServiceException("Invalid Member");
            }

            _context.Add(employee);
            _context.SaveChangesAsync();
            _logger.LogInformation("Employee added " + employee.Id);

            return employee;
        }

        public EmployeeTest.Models.Employee Details(int id)
        {
            var employee = _context.Employees.FirstOrDefault(m => m.Id == id);

            if (employee == null)
            {
                throw new ServiceException("Not Found");
            }
            
            return employee;
        }

        public EmployeeTest.Models.Employee Edit(EmployeeTest.Models.Employee employee)
        {
            _context.Update(employee);
            _context.SaveChangesAsync();
            _logger.LogInformation("Employee updated " + employee.Id);

            return employee;
        }
    }
}
