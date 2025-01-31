using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Html;


namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee data is required.");
            }

            // Create a new Employee entity
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                Salary = employeeDto.Salary
            };

            // Add the employee to the database
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();


            return Ok(employee);
        }

        [HttpPut]

        public IActionResult Edit(Guid id)
        {
            
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }


        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);

            _context.SaveChanges();

            return Ok(employee);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employee = _context.Employees.ToList();

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);    
        }
    }
}