using Microsoft.EntityFrameworkCore;
using NudeApp.Data;
using NudeApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NudeApp.DAL
{
    public class CategoryDataStore
    {
        private readonly NudeAppContext _context;

        public CategoryDataStore(NudeAppContext context) {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var category = await _context.Categories
                .Where(c => c.Name == name)
                .SingleAsync();

            return category;
        }
    }
}