using System;
using System.Collections.Generic;

namespace MethodDI
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public interface IEmployeeDataProvider
    {
        List<Employee> GetEmployees();
    }

    public class EmployeeDataProvider : IEmployeeDataProvider
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Ansh", Department = "IT" },
                new Employee { Id = 2, Name = "Harry", Department = "HR" },
                new Employee { Id = 3, Name = "Pablo", Department = "Finance" }
            };
        }
    }

    public class EmployeeService
    {
        public List<Employee> print(IEmployeeDataProvider obj)
        {
            return obj.GetEmployees();
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeService service = new EmployeeService();
            var result = service.print(new EmployeeDataProvider());

            foreach(var res in result )
            {
                Console.WriteLine(res.Id);
            }
        }
    }
}
