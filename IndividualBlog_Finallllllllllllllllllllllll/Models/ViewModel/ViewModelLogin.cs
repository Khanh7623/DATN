using System.ComponentModel.DataAnnotations;

namespace IndividualBlog.Models.ViewModel
{
    public class ViewModelLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        public string Password { get; set; }
        public bool Rememberme { get; set; }

    }
}
