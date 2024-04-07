using EmployeeManagement.Core.DTO;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employee)
        {
            var newEmployee = await _employeeRepository.AddEmployee(employee);
            return Ok(newEmployee);
        }

        [HttpGet("get-all-employees")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var  employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("get-employee-by-id")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = await _employeeRepository.UpdateEmployee(employee);
            return Ok(employeeToUpdate);
        }
    }
}
