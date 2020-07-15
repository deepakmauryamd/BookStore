using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage="Title of book is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage="Author of book is required.")]
        public string Author { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Language { get; set; }

        [Display(Name="Total pages")]
        [Required(ErrorMessage="Total pages of book is required.")]
        public int? TotalPages { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}