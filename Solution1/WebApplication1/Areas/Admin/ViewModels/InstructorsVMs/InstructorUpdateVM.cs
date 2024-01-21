namespace WebApplication1.Areas.Admin.ViewModels.InstructorsVMs
{
    public class InstructorUpdateVM
    {
        public string Name { get; set; }
        public string? Lastimg { get; set; }
        public IFormFile? ImagePath { get; set; }
        public int ProfessionId { get; set; }
    }
}
