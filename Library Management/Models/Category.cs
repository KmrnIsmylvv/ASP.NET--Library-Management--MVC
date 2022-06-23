﻿using System.Collections.Generic;

namespace Library_Management.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
