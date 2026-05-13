using Microsoft.AspNetCore.Mvc;
using new_testprojectADO.Models;
using new_testprojectADO.Services;

namespace new_testprojectADO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("addemployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            var result = _employeeService.AddEmployee(employee);

            if (result > 0)
            {
                return Ok(new
                {
                    message = "Employee Added Successfully"
                });
            }

            return BadRequest(new
            {
                message = "Failed to Add Employee"
            });
        }


        [HttpGet("getemployees")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();

            return Ok(employees);
        }

        [HttpDelete("deleteemployee/{empId}")]
        public IActionResult DeleteEmployee(int empId)
        {
            var result = _employeeService.DeleteEmployee(empId);

            if (result > 0)
            {
                return Ok(new
                {
                    message = "Employee Deleted Successfully"
                });
            }

            return BadRequest(new
            {
                message = "Failed to Delete Employee"
            });
        }
    }
}