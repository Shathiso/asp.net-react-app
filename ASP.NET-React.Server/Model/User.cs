using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_React.Server.Model
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
