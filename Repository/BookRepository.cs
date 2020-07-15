using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books(){
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description  = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };  

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBook()
        {
            List<BookModel> books = null;
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                books = new List<BookModel>();
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel{
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        TotalPages = book.TotalPages,
                        Author = book.Author 
                    });
                }
            }

            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            BookModel bookDetails = null;
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                bookDetails = new BookModel{
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    TotalPages = book.TotalPages
                };
            }
            return bookDetails;
        }
        public List<BookModel> SearchBook(string name, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(name) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>
            {
                new BookModel{ Id=1, Title="MVC", Author="Deepak" , Description="This is description for book MVC", Category="Programming", TotalPages=1342, Language="English"},
                new BookModel{ Id=2, Title="Java", Author="Nithis" , Description="This is description for book Java" , Category="Coding", TotalPages=4342, Language="English"},
                new BookModel{ Id=3, Title="JavaScript", Author="Nilesh" , Description="This is description for book Javascript" , Category="Web", TotalPages=1542, Language="English"},
                new BookModel{ Id=4, Title="Dotnet", Author="Deepak" , Description="This is description for book Dotnet" , Category="Framework", TotalPages=1312, Language="English"},
                new BookModel{ Id=5, Title="PHP", Author="Someone" , Description="This is description for book PHP", Category="Programming", TotalPages=2313, Language="English"}
            };
        }
    }
}