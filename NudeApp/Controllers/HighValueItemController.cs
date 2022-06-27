using Microsoft.AspNetCore.Mvc;
using NudeApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NudeApp.DAL;
using NudeApp.Services;
using NudeApp.DTO;

namespace NudeApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HighValueItemController : Controller
    {
        private readonly HighValueItemDataStore _highValueItemDataStore;
        private readonly CategoryDataStore _categoryDatastore;
        private readonly CategorizeItemsService _categorizeService;

        public HighValueItemController(HighValueItemDataStore highValueItemDataStore, CategoryDataStore categoryDatastore, CategorizeItemsService categorizeService)
        {
            _highValueItemDataStore = highValueItemDataStore;
            _categoryDatastore = categoryDatastore;
            _categorizeService = categorizeService;
        }

        // GET: api/HighValueItem/GetHighValueItemsPerCategory
        [HttpGet]
        public async Task<IEnumerable<CategoryResponseDTO>> GetHighValueItemsPerCategory()
        {
            var items = await _highValueItemDataStore.GetAllHighValueItems();
            return await _categorizeService.CategorizeHighValueItemsAsync(items);
        }

        // POST: api/HighValueItem/CreateHighValueItem
        [HttpPost]
        public async Task<IActionResult> CreateHighValueItem(HighValueItemRequestDTO highValueItem)
        {
            var category = await _categoryDatastore.GetCategoryByName(highValueItem.Category);

            var created = await _highValueItemDataStore.AddHighValueItem(new HighValueItem {
                Id = Guid.NewGuid(),
                Name = highValueItem.Name,
                Value = highValueItem.Value,
                CategoryId = category.CategoryId
            });

            var items = await _highValueItemDataStore.GetAllHighValueItems();
            var response = await _categorizeService.CategorizeHighValueItemsAsync(items);

            if (!created)
            {
                return NotFound();
            }
            return Ok(response);
        }

        // DELETE: api/HighValueItem/DeleteHighValueItem/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHighValueItem(Guid id)
        {
            var deleted = await _highValueItemDataStore.DeleteHighValueItem(id);
            var items = await _highValueItemDataStore.GetAllHighValueItems();
            var response = await _categorizeService.CategorizeHighValueItemsAsync(items);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}