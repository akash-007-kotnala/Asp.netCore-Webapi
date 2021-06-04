using EmployeeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.EmployeeData
{
    public class MockEmployeeData : IEmployeeData, IMockEmployeeData
    {
        //hard code some employee. By using the emtity in model with there property define like id and name..

        private  List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Akash"
            },

            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Krishna"
            },
        };

        

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();

            //Employeess array mai add karne ko..
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;


        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
