using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ef_platzy.Models
{
    public class Ef_PlatzyContex : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public Ef_PlatzyContex(DbContextOptions<Ef_PlatzyContex> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(Category =>
            {
                // USE FLUENT API -- IMPLEMENT ATTRIBUTES TO THE CLASSES
                Category.ToTable("Category");
                Category.HasKey(p => p.CategoryId);
                Category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                Category.Property(p => p.Description);
            });

            modelBuilder.Entity<Task>(Task =>
            {
                Task.ToTable("Task");
                Task.HasKey(p => p.TaskId);
                Task.HasOne(p => p.Category).WithMany(p => p.Task).HasForeignKey(p => p.CategoryId);
                Task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                Task.Ignore(p => p.Summary);
            });
        }
    }
}