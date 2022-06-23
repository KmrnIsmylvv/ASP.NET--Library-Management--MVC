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
    }
}
