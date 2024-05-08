using ASP.NET_React.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;


namespace ASP.NET_React.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EmployeeContext _dataContext;

        public UserController(EmployeeContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet(Name = "users")]
        public async Task<IEnumerable<User>> Get()
        {
            try {
                var userData = await _dataContext.Users.Include(u => u.Employee).ToArrayAsync();
                return userData;

            } catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        [HttpPost(Name = "users")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), user);
        }


    }
}
