using System;
using System.Collections.Generic;

namespace Library_Management.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GivenTime { get; set; }
        public bool IsCompleted { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

    }
}
