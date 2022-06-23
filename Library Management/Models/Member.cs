using System.Collections.Generic;

namespace Library_Management.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string University { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }


        public IEnumerable<Punishment> Punishments{ get; set; }
        public IEnumerable<Sales> Sales { get; set; }
    }
}
