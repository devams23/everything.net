using EF_CORE_Final_PROJECT.Data;
using EF_CORE_Final_PROJECT.Models;


namespace EF_CORE_Final_PROJECT.Services
{
    internal class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Employee> GetAllEmployees()
        {
            try
            {
                var employees = _context.Employees.ToList();
                if (employees.Count!=0)
                {
                    return employees;
                }
                else
                {
                    return new List<Employee>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Employee>();
            }
        }


    }
}
