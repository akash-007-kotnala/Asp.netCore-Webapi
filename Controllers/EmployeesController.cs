using EmployeeApp.EmployeeData;
using EmployeeApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Controllers
{
   
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //creating one field..
        private IEmployeeData _employeeData;

        //Injection of field...
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
         [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            //Getting data from mockrepository and giving data back obj hence Ok
            return Ok(_employeeData.GetEmployees());
        }

        //For getting the single employee from its id..
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employeeInfo = _employeeData.GetEmployee(id);

            if(employeeInfo != null)
            {
                return Ok(employeeInfo);
            }
            //Getting data from mockrepository and giving data back obj hence Ok
            return NotFound($"Empmloyee with Id: {id} was not found.");
        }

        //Creating new employeee.

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }


        //Delete new employeee.

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {

            var employee = _employeeData.GetEmployee(id);

            if(employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee with Id: {id} not found");
        }


        //Editing the new employee..


        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {

            var existingemployee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                employee.Id = existingemployee.Id;
                _employeeData.EditEmployee(employee);
                return Ok();
            }
            else if (employee == null) 
            {
                return NotFound($"Employee with Id: {id} not found");
            }
            else
            {
                return NotFound($"Cannot edit the id..");
            }

        }


    }
}
