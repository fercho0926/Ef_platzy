using Ef_platzy.Enum;
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
            List<Category> SeedCategory = new List<Category>();
            SeedCategory.Add(new Category()
            {
                CategoryId = Guid.Parse("D25EB6C9-B078-4771-A1A1-CCC9A7CD0755"),
                Name = "Pending Activities",
                Effort = 20
            });
            SeedCategory.Add(new Category()
            {
                CategoryId = Guid.Parse("62DD1227-8D77-4ED6-B811-DDC4530C97AE"),
                Name = "Personal Activities",
                Effort = 50
            });


            List<Task> SeedTask = new List<Task>();
            SeedTask.Add(new Task()
            {
                TaskId = Guid.Parse("03EBB742-CBB2-46B4-A8A8-957F4AE873BD"),
                CategoryId = Guid.Parse("D25EB6C9-B078-4771-A1A1-CCC9A7CD0755"),
                priority = Priority.Middle,
                Title = "Public Services pay",
                DateCreated = DateTime.Now
            });
            SeedTask.Add(new Task()
            {
                TaskId = Guid.Parse("57B67926-B7FE-4A04-84D7-EC800DFDF7A5"),
                CategoryId = Guid.Parse("D25EB6C9-B078-4771-A1A1-CCC9A7CD0755"),
                priority = Priority.Hight,
                Title = "pay the house cleaning",
                DateCreated = DateTime.Now
            });

            SeedTask.Add(new Task()
            {
                TaskId = Guid.Parse("B3A7249F-5D58-4AE6-AA6B-43DD7C3D7807"),
                CategoryId = Guid.Parse("62DD1227-8D77-4ED6-B811-DDC4530C97AE"),
                priority = Priority.Low,
                Title = "Call mom",
                DateCreated = DateTime.Now
            });


            modelBuilder.Entity<Category>(Category =>
            {
                // USE FLUENT API -- IMPLEMENT ATTRIBUTES TO THE CLASSES
                Category.ToTable("Category");
                Category.HasKey(p => p.CategoryId);
                Category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                Category.Property(p => p.Description).IsRequired(false);
                Category.Property(p => p.Effort);

                Category.HasData(SeedCategory);
            });

            modelBuilder.Entity<Task>(Task =>
            {
                Task.ToTable("Task");
                Task.HasKey(p => p.TaskId);
                Task.HasOne(p => p.Category).WithMany(p => p.Task).HasForeignKey(p => p.CategoryId);
                Task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                Task.Ignore(p => p.Summary);
                Task.Property(p => p.Description).IsRequired(false);

                Task.HasData(SeedTask);
            });
        }
    }
}