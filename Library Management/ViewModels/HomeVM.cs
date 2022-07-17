using Library_Management.Models;
using System.Collections.Generic;

namespace Library_Management.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Book> Books { get; set; }
        public About About { get; set; }
    }
}
