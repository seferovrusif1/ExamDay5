using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AppUser:IdentityUser
    {
        [Required,MinLength(3),MaxLength(32)]
        public string FullName { get; set; }
    }
}
