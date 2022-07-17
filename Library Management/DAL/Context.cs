using Library_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CashBox> CashBoxes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Punishment> Punishments { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}
