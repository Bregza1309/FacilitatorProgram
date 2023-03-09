using System.ComponentModel.DataAnnotations;
namespace FacilitatorProgram.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Please enter Student FirstName")]
        [StringLength(30)]
        public string FirstName { get; set; }   = string.Empty;
        [Required(ErrorMessage = "Please enter Student LastName")]
        [StringLength(30)]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please enter Student Email")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter Student Address 1")]
        [StringLength(50)]
        public string Address1 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter Student Address 2")]
        [StringLength(50)]
        public string Address2 { get; set; } = string.Empty;
    }
}
