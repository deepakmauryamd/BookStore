using System.Collections.Generic;
using System.Linq;
using BookStore.Models;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBook()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string name, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(name) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>
            {
                new BookModel{ Id=1, Title="MVC", Author="Deepak" },
                new BookModel{ Id=2, Title="Java", Author="Nithis" },
                new BookModel{ Id=3, Title="JavaScript", Author="Nilesh" },
                new BookModel{ Id=4, Title="Dotnet", Author="Deepak" },
                new BookModel{ Id=5, Title="PHP", Author="Someone" }
            };
        }
    }
}