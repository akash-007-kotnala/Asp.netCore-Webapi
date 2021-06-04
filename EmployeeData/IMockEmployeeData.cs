using EmployeeApp.Model;
using System;
using System.Collections.Generic;

namespace EmployeeApp.EmployeeData
{
    public interface IMockEmployeeData
    {
        Employee AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
        Employee GetEmployee(Guid id);
        List<Employee> GetEmployees();
    }
}
