using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class ExamDay5DBContext : IdentityDbContext<AppUser>
    {
        public ExamDay5DBContext(DbContextOptions options) : base(options){}
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }

    }
}
