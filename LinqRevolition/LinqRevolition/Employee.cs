using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRevolition
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Salary { get; set; }
        public string City { get; set; }

        public DateOnly BirthDate { get; set; }


    }

    public class EmployeeService
    {
        private List<Employee> employees = new List<Employee>()
        {
             new Employee() { Id = 1, FirstName="Nihat", LastName="Doğan", Salary=16000, City="Kayseri"},
             new Employee() { Id = 2, FirstName="Nagihan", LastName="Esendal", Salary=65000, City="İstanbul"},
             new Employee() { Id = 3, FirstName="Serkan", LastName="Bayrak", Salary=80000, City ="İstanbul"},
             new Employee() { Id = 4, FirstName="Nihat", LastName="Doğan", Salary=65000, City ="Kayseri"}


        };


        public List<Employee> GetEmployees() => employees;



    }
}
