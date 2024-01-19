using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Instructor:BaseModel
    {
        [Required,MinLength(3),MaxLength(32)]
        public string Name {  get; set; }
        [Required]
        public int ProfessionId { get; set; }
        public Profession? Profession { get; set; }
        public IEnumerable<SocialMediaLink>? SocialMediaLinks { get; set; }

    }
}
