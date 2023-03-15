using Microsoft.EntityFrameworkCore;

namespace TodoContextDB.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext()
        {
        }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
