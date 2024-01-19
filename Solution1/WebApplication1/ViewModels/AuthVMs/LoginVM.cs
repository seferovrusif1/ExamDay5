using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.AuthVMs
{
    public class LoginVM
    {
        [Required,MinLength(3),MaxLength(256)]
        public string UsernameOrEmail { get; set; }
        [Required, MinLength(6), MaxLength(256)]
        public string Password { get; set; }
    }
}
