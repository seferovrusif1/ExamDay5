using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class ExamDay5DBContext : IdentityDbContext<AppUser>
    {
        public ExamDay5DBContext(DbContextOptions options) : base(options) { }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }
        public DbSet<setting> setting { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<setting>()
                .HasData(new setting
                {
                    Id = 1,
                    Adress = "adrs",
                    Phone = "+994 32 42323",
                    Email = "lsda@dsd",
                    Fb = "www.facebook.com",
                    Yt = "www.Youtube.com",
                    Insta = "www.Instagram.com",
                    Linkedin = "www.Linkedin.com",
                    Twitter = "www.Twitter.com",
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
