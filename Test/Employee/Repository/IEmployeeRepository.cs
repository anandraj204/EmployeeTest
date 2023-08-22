namespace EmployeeTest.Repository
{
    public interface IEmployeeRepository
    {
        public List<EmployeeTest.Models.Employee> GetAll();
        public EmployeeTest.Models.Employee Create(EmployeeTest.Models.Employee employee);
        public EmployeeTest.Models.Employee Edit(EmployeeTest.Models.Employee employee);
        public EmployeeTest.Models.Employee Details(int id);
    }
}
