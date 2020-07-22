using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class UserLoginModel
    {
        public int Id { get; set; }

        [Display(Name="Username or email")]
        [Required]
        public string Username { get; set; }

        [Display(Name="Enter password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}