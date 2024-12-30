using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly HrbuddyContext _context;

        public DemoController(HrbuddyContext context)
        {
            _context = context;
        }

        [HttpGet("GetCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching customers", error = ex.Message });
            }
        }


        [HttpGet("GetDepartments")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            try
            {
                var Departments = await _context.Departments.ToListAsync();
                return Ok(Departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching customers", error = ex.Message });
            }
        }

        [HttpGet("GetEmployeeAssignment")]
        public async Task<ActionResult<IEnumerable<EmployeeAssignment>>> GetEmployeeAssignments()
        {
            try
            {
                var EmployeeAssignments = await _context.EmployeeAssignments.ToListAsync();
                return Ok(EmployeeAssignments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching EmployeeAssignments", error = ex.Message });
            }
        }

        [HttpPost("AddDepartment")]
        public async Task<ActionResult> AddDepartment([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest(new { message = "Invalid department data" });
            }
            try
            {
                // Add the department to the database
                await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();

                // Return success response
                return CreatedAtAction(nameof(GetDepartments), new { id = department.DepartmentId }, department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the department", error = ex.Message });
            }
        }







    }
}
