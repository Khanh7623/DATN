using IndividualBlog.Utilties.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace IndividualBlog.Models.ViewModel
{
    public class ViewModelRegisterUser
    {
        [Required]
        [StringLength(50)]
        public string FirtName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Must be between 6 and 128 characters", MinimumLength =6)]
        public string Password { get; set; }
        [Compare("Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(128, ErrorMessage = "Must be between 6 and 128 characters", MinimumLength = 6)]
        public string PasswordConfirm { get; set; }
        public EUserStatus Status { get; set; } = EUserStatus.Active;
    }
}
