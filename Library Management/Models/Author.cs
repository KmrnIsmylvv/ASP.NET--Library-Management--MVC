using System.Collections.Generic;

namespace Library_Management.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
