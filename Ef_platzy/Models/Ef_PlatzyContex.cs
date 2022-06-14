using Microsoft.EntityFrameworkCore;

namespace Ef_platzy.Models
{
    public class Ef_PlatzyContex : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public Ef_PlatzyContex(DbContextOptions<Ef_PlatzyContex> options) : base(options)
        {
        }
    }
}