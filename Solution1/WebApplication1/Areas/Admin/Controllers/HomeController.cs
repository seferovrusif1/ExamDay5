using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Areas.Admin.ViewModels.InstructorsVMs;
using WebApplication1.Context;
using WebApplication1.Helpers;

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
            int take = 1;
            var data = _db.Instructors.Take(take).Select(x => new InstructorListItemVM
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath=x.ImagePath,
                Profession=x.Profession.Title,
                SocialMediaLinks = x.SocialMediaLinks.Select(y=>y.Link).ToList(),
                IsDeleted = x.IsDeleted
            });
            int count=_db.Instructors.Where(x=>!x.IsDeleted).Count();
            PaginationVM<IEnumerable<InstructorListItemVM>> page = new(1, (int)Math.Ceiling(count / (decimal)take), count, data);
            return View(page);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Profession = _db.Professions;
            ViewBag.SMLinks = _db.SocialMediaLinks;
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(InstructorCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Profession = _db.Professions;
                ViewBag.SMLinks = _db.SocialMediaLinks;
                return View(vm);
            }
        
            await _db.Instructors.AddAsync(new Models.Instructor
            {
                Name = vm.Name,
                ImagePath = await vm.ImagePath.SaveImage(PathConstants.ImageFolder),
                ProfessionId = vm.ProfessionId,
            }) ;
            await _db.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Profession = _db.Professions;
            ViewBag.SMLinks = _db.SocialMediaLinks;
            var data = await _db.Instructors.FindAsync(id);
            var vm = new InstructorUpdateVM
            {

                Name = data.Name,
                Lastimg = data.ImagePath,
                ProfessionId = data.ProfessionId
            };
            return View(vm);
        }
        [HttpPost]

        public async Task<IActionResult> Update(int id, InstructorCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Profession = _db.Professions;
                ViewBag.SMLinks = _db.SocialMediaLinks;
                return View(vm);
            }
            var data = await _db.Instructors.FindAsync(id);
            data.Name = vm.Name;
            string limg = Path.Combine(PathConstants.RootPath, data.ImagePath);
            if (System.IO.File.Exists(limg))
            {
                System.IO.File.Delete(limg);
            };
            data.ImagePath = await vm.ImagePath.SaveImage(PathConstants.ImageFolder);
            data.ProfessionId = vm.ProfessionId;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Pagination(int currentpage = 1, int take = 1)
        {
            var data = _db.Instructors.Skip((currentpage - 1) * take).Take(take).Select(x => new InstructorListItemVM
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                Profession = x.Profession.Title,
                SocialMediaLinks = x.SocialMediaLinks.Select(y => y.Link).ToList(),
                IsDeleted = x.IsDeleted
            });
            int count = _db.Instructors.Where(x => !x.IsDeleted).Count();
            PaginationVM<IEnumerable<InstructorListItemVM>> page = new(1, (int)Math.Ceiling(count / (decimal)take), count, data);
            return PartialView("_instructorPaginationPartial", page);

        }

    }
    }
