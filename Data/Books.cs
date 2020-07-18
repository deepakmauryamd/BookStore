using System;
using System.Collections.Generic;

namespace BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public int CategoryId { get; set; }
        public uint TotalPages { get; set; }
        public string CoverImageUrl {get; set;}
        public string BookPdfUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Language Language { get; set; }
        public Category Category {get; set;}
        public ICollection<BookGalary> bookGalary {get; set;}
    }
}