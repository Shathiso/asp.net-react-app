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
            return await  _dataContext.Employees.ToArrayAsync();
        }


        [HttpPost(Name = "employees")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(Employee employee)
        {
            await _dataContext.Employees.AddAsync(employee);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), employee);
        }
    }
}
