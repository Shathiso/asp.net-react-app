using ASP.NET_React.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_React.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _dataContext;

        public EmployeeController(EmployeeContext dataContext) {
            _dataContext = dataContext;
        }

        [HttpGet(Name = "employees")]
        public async Task<IEnumerable<Employee>> Get()
        {
            try
            {
                var employeeData = await _dataContext.Employees.Include(e => e.User).ToArrayAsync();
                return employeeData;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if(_dataContext.Employees == null)
            {
                return NotFound();
            }

            var employeeData = await _dataContext.Employees.FindAsync(id);

            if (employeeData == null)
            {
                return NotFound();
            }

            return employeeData;
        }


        [HttpPost(Name = "employees")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(Employee employee)
        {
            await _dataContext.Employees.AddAsync(employee);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), employee);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            if (_dataContext.Employees == null)
            {
                return NotFound();
            }

            var employee = await _dataContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _dataContext.Employees.Remove(employee);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.id)
            {
                return BadRequest();
            }

            _dataContext.Entry(employee).State = EntityState.Modified;


            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _dataContext.Employees.Any(e => e.id == id);
        }
    }
}
