using Microsoft.EntityFrameworkCore;

namespace ASP.NET_React.Server.Model
{
    public class EmployeeContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        public EmployeeContext(DbContextOptions options) : base(options) { 
        
        
        }
    }
}
