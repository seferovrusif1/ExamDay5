using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Profession:BaseModel
    {
        [Required,MinLength(2),MaxLength(128)]
        public string Title { get; set; }
        public IEnumerable<Instructor>? Instructors { get; set; }

    }
}
