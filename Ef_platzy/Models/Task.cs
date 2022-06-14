using Ef_platzy.Enum;

namespace Ef_platzy.Models
{
    public class Task
    {
        //[Key] -- not necessary, i already implement, FLUENT API
        public Guid TaskId { get; set; }

        //[ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        //[Required, MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority priority { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }

        //[NotMapped] // Do NOT CREATE THE FIELD IN THE DATABASE
        public string Summary { get; set; }
    }
}