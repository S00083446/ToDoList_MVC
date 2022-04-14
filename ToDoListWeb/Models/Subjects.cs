using System.ComponentModel.DataAnnotations;

namespace ToDoListWeb.Models
{
    public class Subjects
    {
        [Key] // SQL Identity Column
        public int Id { get; set; }
        [Required] // Name cannot be null
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int DisplayOrder { get; set; }

    }
}
