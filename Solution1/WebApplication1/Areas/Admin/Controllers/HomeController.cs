using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.ViewModels.InstructorsVMs;
using WebApplication1.Context;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        ExamDay5DBContext _db {  get; set; }

        public HomeController(ExamDay5DBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = _db.Instructors.Select(x => new InstructorListItemVM
            {
                Id = x.Id,
                Name = x.Name,
                Profession=x.Profession.Title,
                SocialMediaLinks = x.SocialMediaLinks.Select(y=>y.Link).ToList(),
                IsDeleted = x.IsDeleted
            }).ToList();
            return View(data);
        }
    }
}
