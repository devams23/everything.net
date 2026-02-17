
// File created on 2026-02-2


namespace LINQ.DAY1
{
    
    class LinqProgram
    {
        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.Name}, Salary: {emp.Salary}");
            }
            Console.WriteLine("--------------------------------------------------");
        }
        static void Main(string[] args)
        {
            // getting employee data
            Employee employeeData = new Employee();
            var employees = employeeData.GetAllEmployees();

            /* 
             * also LINQ work in such a way that it only gets executed when we iterate over the data, or
            call ToList() or ToArray() on it.

            -- Linq feature used - Where(), because we are filtering the data on some
            condition, and "Where()" is the method which accepts a function of boolean return type.
            */
            #region TASK1
            var highSalaryEmployees = employees.Where(e => e.Salary > 25000).ToList();
            DisplayEmployees(highSalaryEmployees);

            #endregion

            #region TASK2

            #endregion

            #region TASK3

            #endregion

            #region TASK4

            #endregion

            #region TASK5

            #endregion

            #region TASK6

            #endregion
            #region TASK7

            #endregion
            #region TASK8

            #endregion
            #region TASK9

            #endregion
            #region TASK10

            #endregion

        }
    }
}
