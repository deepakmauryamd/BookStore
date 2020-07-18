using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title of book is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author of book is required.")]
        public string Author { get; set; }

        public string Description { get; set; }

        [Display(Name="Select category of book")]
        public int CategoryId { get; set; }
        public string Category { get; set; }

        [Display(Name="Select language of book")]
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Display(Name = "Total pages")]
        [Required(ErrorMessage = "Total pages of book is required.")]
        public uint? TotalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Display(Name="Cover photo of book")]
        [Required]
        public IFormFile CoverPhoto {get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name="Images of book")]
        [Required]
        public IFormFileCollection GalaryImages {get; set; }

        public List<GalaryModel> Galary { get; set; }

        [Display(Name="Upload book in pdf format")]
        [Required]
        public IFormFile BookPdf {get; set; }
        public string BookPdfUrl { get; set; }
    }
}