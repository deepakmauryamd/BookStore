using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.ViewModels
{
    public class BookVM
    {
        public BookModel book { get; set; } 
        public IEnumerable<BookModel> similarBooks { get; set; }
    }
}