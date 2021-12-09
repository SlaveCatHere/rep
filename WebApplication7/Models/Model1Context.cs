using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class Model1Context : DbContext
    {
        public DbSet<Model1> models1 { get; set; }
        public Model1Context(DbContextOptions<Model1Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
