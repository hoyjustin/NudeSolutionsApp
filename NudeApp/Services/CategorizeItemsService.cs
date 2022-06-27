using NudeApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using NudeApp.DAL;
using NudeApp.DTO;

namespace NudeApp.Services
{
    public class CategorizeItemsService
    {
        private readonly CategoryDataStore _dataStore;

        public CategorizeItemsService(CategoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        /// <summary>
        /// Groups the given HighValueItems on their categories.
        /// </summary>
        public async Task<IEnumerable<CategoryResponseDTO>> CategorizeHighValueItemsAsync(IEnumerable<HighValueItem> items)
        {
            List<Category> categories = await _dataStore.GetAllCategories();
            Dictionary<Guid, Category> categoryLookup = categories.ToDictionary(c => c.CategoryId);

            IEnumerable<CategoryResponseDTO> itemsGroupedByCategory = items
                .GroupBy(i => i.CategoryId)
                .Select(cg => {
                    categoryLookup.TryGetValue(cg.Key, out Category category);
                    return new CategoryResponseDTO {
                        CategoryId = category.CategoryId,
                        Name = category.Name,
                        Items = cg.Select(i => new HighValueItemResponseDTO {
                            Id = i.Id,
                            Name = i.Name,
                            Value = i.Value
                        }).ToArray(),
                        TotalValue = cg.Sum(i => i.Value)
                    };
                });

            return itemsGroupedByCategory;
        }
    }
}