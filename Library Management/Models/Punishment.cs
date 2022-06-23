using System;

namespace Library_Management.Models
{
    public class Punishment
    {
        public int Id { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public decimal Money { get; set; }


    }
}
