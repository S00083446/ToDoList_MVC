using System.ComponentModel;
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
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display Number must be between 1 and 100")]
        public int DisplayOrder { get; set; }

    }
}
