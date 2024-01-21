using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.ViewModels.InstructorsVMs
{
    public class InstructorCreateVM
    {
        public string Name { get; set; }
        public IFormFile ImagePath { get; set; }
        public int ProfessionId { get; set; }

    }
}
