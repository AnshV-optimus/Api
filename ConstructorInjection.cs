//namespace Dotnet
//{

//    public class Employee
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Department { get; set; }

//    }
//    public interface IEmployeeDetails
//    {
//        List<Employee> GetDetails();
//    }

//    public class GetData: IEmployeeDetails
//    {
//        public List<Employee> GetDetails()
//        {
//            List<Employee> EmpList = new List<Employee>()
//            {
//                new Employee { Id = 1,Name = "Ansh" , Department = "IT" },
//                new Employee { Id = 2, Name = "harry" , Department = "IT" },
//                new Employee { Id = 3, Name = "Pablo" , Department = "HR" }
//            };


//            return EmpList;
//        }
//    }

//    public class validation
//    {
//        GetData _getData;
//        public validation(GetData _getData)
//        {
//            this._getData = _getData;
//        }
//        public List<Employee> GetAllEmployees()
//        {
//            return _getData.GetDetails();
//        }
//    }

//    internal class ConstructorInjection
//    {
//        static void Main(string[] args)
//        {
//            validation obj = new validation(new GetData());
//            List<Employee>EmpList =  obj.GetAllEmployees();

//            foreach (Employee emp in EmpList)
//            {
//                Console.WriteLine($"{emp.Name} {emp.Department} ");
                
//            }

//        }
//    }
//}
