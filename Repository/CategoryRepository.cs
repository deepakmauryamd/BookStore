using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class CategoryRepository
    {
        private readonly BookStoreContext _context = null;
        public CategoryRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return await _context.Category.Select(category => new CategoryModel{
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            }).ToListAsync();
        }

        
    }
}