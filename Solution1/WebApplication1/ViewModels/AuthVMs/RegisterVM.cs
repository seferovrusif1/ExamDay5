using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.AuthVMs
{
    public class RegisterVM
    {
        [Required, MinLength(3), MaxLength(256)]
        public string FullName { get; set; }
        [Required, MinLength(3), MaxLength(256)]
        public string Username { get; set; }

        [Required, MinLength(3), MaxLength(256)]
        public string Email { get; set; }
        [Required, MinLength(6), MaxLength(256)]
        public string Password { get; set; }
    }
}
