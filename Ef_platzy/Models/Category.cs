namespace Ef_platzy.Models
{
    public class Category
    {
        //[Key] -- not necessary, i already implement, FLUENT API
        public Guid CategoryId { get; set; }

        //[Required, MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public int Effort { get; set; }
    }
}