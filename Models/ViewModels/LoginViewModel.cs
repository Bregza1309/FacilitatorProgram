using System.ComponentModel.DataAnnotations;
namespace FacilitatorProgram.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please enter your Username")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; } = string.Empty;
    }
}
