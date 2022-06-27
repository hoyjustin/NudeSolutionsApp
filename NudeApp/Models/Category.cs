using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NudeApp.Models
{
    public class Category {
        public Guid CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<HighValueItem> HighValueItem { get; set; }
    }
}