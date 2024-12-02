//using System;
//using System.Collections.Generic;

//namespace Dotnet
//{
//    public class Employee
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Department { get; set; }
//    }

//    public interface IEmployees
//    {
//        List<Employee> GetEmployees();
//    }

//    public class GetData : IEmployees
//    {
//        public List<Employee> GetEmployees()
//        {
//            List<Employee> EmpList = new List<Employee>()
//            {
//                new Employee { Id = 1, Name = "Ansh", Department = "IT" },
//                new Employee { Id = 2, Name = "Harry", Department = "IT" },
//                new Employee { Id = 3, Name = "Pablo", Department = "HR" }
//            };
//            return EmpList;
//        }
//    }

//    public class PrintData
//    {
//        public IEmployees? Employees { get; set; } 

//        public List<Employee> Print()
//        {
//            if (Employees == null) 
//            {
//                throw new InvalidOperationException("Employees property is not set.");
//            }

//            return Employees.GetEmployees();
//        }
//    }

//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            PrintData emp = new PrintData();
//            emp.Employees = new GetData(); // Dependency Injection through property

//            var result = emp.Print();

//            foreach (var res in result)
//            {
//                Console.WriteLine(res.Name);
//            }
//        }
//    }
//}

