using System.ComponentModel.DataAnnotations;

namespace EmployeeTest.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
