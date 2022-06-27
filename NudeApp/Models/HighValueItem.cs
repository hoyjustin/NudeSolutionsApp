using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NudeApp.Models
{
    public class HighValueItem
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Value { get; set; }

        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }

}
