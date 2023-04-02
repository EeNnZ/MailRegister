using MailRegisterServer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailRegisterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public EmployeesController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IDictionary<int, string>>> GetEmployees()
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.ToDictionaryAsync(emp => emp.Id, emp => emp.ToString());
            return employees;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KeyValuePair<int, string>>> GetEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return new KeyValuePair<int, string>(employee.Id, employee.ToString());
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee) => StatusCode(403);

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee) => StatusCode(403);

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id) => StatusCode(403);

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
