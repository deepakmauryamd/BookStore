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
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            newBook.bookGalary = new List<BookGalary>();
            foreach(var image in model.Galary)
            {
                newBook.bookGalary.Add(new BookGalary{
                    Url = image.Url,
                    Name = image.Name
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBook()
        {
            var allbooks = await _context.Books.Select(
                book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Author = book.Author,
                    CoverImageUrl = book.CoverImageUrl
                }).ToListAsync();

            return allbooks;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    TotalPages = book.TotalPages,
                    Galary =  book.bookGalary.Select(galary => new GalaryModel{
                        Name= galary.Name,
                        Url = galary.Url
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl
                }).FirstOrDefaultAsync();

        }
        public List<BookModel> SearchBook(string name, string authorName)
        {
            return null;
        }
    }
}