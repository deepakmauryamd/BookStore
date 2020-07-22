using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class UserRegistorModel
    {
        public int Id { get; set; }

        [Display(Name="Username or email")]
        [Required]
        public string Username { get; set; }

        [Display(Name="Choose a password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Confirm password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",
            ErrorMessage = "Password and confirm password does not match.")]
        public string ConfirmPassword { get; set; }
    }
}