using NudeApp.DAL;
using System;

namespace NudeApp.DTO
{
    public class CategoryResponseDTO
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public decimal TotalValue { get; set; }

        public HighValueItemResponseDTO[] Items { get; set; }
    }
}