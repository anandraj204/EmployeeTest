namespace EmployeeTest.Repository
{
    public class ServiceException : Exception
    {
        public ServiceException() : base()
        {

        }

        public ServiceException(string message) : base(message)
        {

        }
    }
}
