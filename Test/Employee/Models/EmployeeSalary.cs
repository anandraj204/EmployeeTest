using System.ComponentModel.DataAnnotations;

namespace EmployeeTest.Models
{
    public class EmployeeSalary
    {
        [Key]
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
