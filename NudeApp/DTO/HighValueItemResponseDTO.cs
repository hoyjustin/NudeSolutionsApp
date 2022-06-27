using System;

namespace NudeApp.DAL
{
    public class HighValueItemResponseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}