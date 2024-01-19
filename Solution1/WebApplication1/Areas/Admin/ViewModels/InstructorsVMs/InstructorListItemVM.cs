using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.ViewModels.InstructorsVMs
{
    public class InstructorListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public IEnumerable<string>? SocialMediaLinks { get; set; }
        public int IsDeleted { get; set; }
    }
}
