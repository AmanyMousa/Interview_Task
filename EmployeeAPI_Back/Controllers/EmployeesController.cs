using EmployeeAPI_Back.Models;
using EmployeeAPI_Back.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
            private readonly IEmployeeRepository _employeeRepository;

            public EmployeesController(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }

            // GET: api/Employees
            [HttpGet("GetAll")]
            public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(
                [FromQuery] int pageNumber = 1,
                [FromQuery] int pageSize = 10,
                [FromQuery] string searchTerm = "")
            {
                var employees = await _employeeRepository.GetEmployees(pageNumber, pageSize, searchTerm);
                return Ok(employees);
            }

            // GET: api/Employees/5
            [HttpGet("GetBy/{id}")]
            public async Task<ActionResult<Employee>> GetEmployee(int id)
            {
                var employee = await _employeeRepository.GetEmployee(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return employee;
            }

            // PUT: api/Employees/[id]
            [HttpPut("Update/{id}")]
            public async Task<IActionResult> PutEmployee(int id, Employee employee)
            {
            employee.Id = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                await _employeeRepository.UpdateEmployee(employee);
            }
            catch
            {
                if (await _employeeRepository.GetEmployee(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }

                return NoContent();
            }

            // POST: api/Employees
            [HttpPost("New")]
            public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
            {
               if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
               }

            var createdEmployee = await _employeeRepository.AddEmployee(employee);
            return CreatedAtAction("GetEmployee", new { id = createdEmployee.Id }, createdEmployee);
             }

            // DELETE: api/Employee/5
            [HttpDelete("Delete/{id}")]
            public async Task<IActionResult> DeleteEmployee(int id)
            {
                await _employeeRepository.DeleteEmployee(id);
                return NoContent();
            }
    }
}
