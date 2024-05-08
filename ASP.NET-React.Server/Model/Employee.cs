namespace ASP.NET_React.Server.Model
{
    public class Employee
    {

        /*
         * 'first_name',
        'last_name',
        'contact_number',
        'email_address',
        'birth_date',
        'street_address',
        'city',
        'postal_code',
        'country'
        skills
         */

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int contact_number { get; set; }
        public DateTime birth_date { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }

        public virtual User User { get; set; }
    }
}
