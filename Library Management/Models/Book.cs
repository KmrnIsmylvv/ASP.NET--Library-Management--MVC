using System.Collections.Generic;

namespace Library_Management.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublishDate { get; set; }
        public string PublishHome { get; set; }
        public string PageNumber { get; set; }
        public bool InStock { get; set; }

        public IEnumerable<Sales> Sales { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
