using Microsoft.EntityFrameworkCore;
using NudeApp.Data;
using NudeApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NudeApp.DAL
{
    public class HighValueItemDataStore
    {
        private readonly NudeAppContext _context;

        public HighValueItemDataStore(NudeAppContext context) {
            _context = context;
        }

        public async Task<List<HighValueItem>> GetAllHighValueItems()
        {
            return await _context.HighValueItems.ToListAsync();
        }

        public async Task<HighValueItem> GetHighValueItem(Guid id)
        {
            return await _context.HighValueItems.FindAsync(id);
        }

        public async Task<bool> AddHighValueItem(HighValueItem item)
        {
            _context.HighValueItems.Add(item);
            int x = await _context.SaveChangesAsync();
            return x != 0;
        }

        public async Task<bool> DeleteHighValueItem(Guid id)
        {
            HighValueItem item = new HighValueItem() { Id = id };
            _context.HighValueItems.Attach(item);
            _context.Remove(item);
            int x = await _context.SaveChangesAsync();
            return x != 0;
        }
    }
}