using System.ComponentModel.DataAnnotations;
namespace FacilitatorProgram.Models.ViewModels
{
    public class RegisterViewModel:LoginViewModel
    {
        [Required(ErrorMessage ="Please confirm your password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
