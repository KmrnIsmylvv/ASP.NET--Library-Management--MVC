using Microsoft.EntityFrameworkCore;

namespace Library_Management.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
