using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SocialMediaLink:BaseModel
    {
        [Required, MaxLength(64)]
        public string Icon { get; set; }
        [Required, MaxLength(512)]
        public string Link { get; set; }
        public Instructor? Instructor { get; set; }
        public int? InstructorId { get; set; }

    }
}
