using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NudeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class HighValueItemConfiguration : IEntityTypeConfiguration<HighValueItem>
{
    public void Configure(EntityTypeBuilder<HighValueItem> builder)
    {
        builder.HasKey(i => i.Id);
        builder.HasOne(i => i.Category)
            .WithMany(c => c.HighValueItem)
            .HasForeignKey(i => i.CategoryId);

        Category electronics = CategoryConfiguration.initialCategories.First(c => c.Name == "Electronics");
        Category clothing = CategoryConfiguration.initialCategories.First(c => c.Name == "Clothing");
        Category kitchen = CategoryConfiguration.initialCategories.First(c => c.Name == "Kitchen");

        IEnumerable<HighValueItem> initialHighValueItems = new List<HighValueItem>()
        {
            new HighValueItem { Id = Guid.NewGuid(), Name = "TV", Value = 2000m, CategoryId = electronics.CategoryId },
            new HighValueItem { Id = Guid.NewGuid(), Name = "Playstation", Value = 400m, CategoryId = electronics.CategoryId },
            new HighValueItem { Id = Guid.NewGuid(), Name = "Stereo", Value = 1600m, CategoryId = electronics.CategoryId },
            new HighValueItem { Id = Guid.NewGuid(), Name = "Shirts", Value = 1100m, CategoryId = clothing.CategoryId },
            new HighValueItem { Id = Guid.NewGuid(), Name = "Jeans", Value = 1100m, CategoryId = clothing.CategoryId },
            new HighValueItem { Id = Guid.NewGuid(), Name = "Pots and Pans", Value = 3000m, CategoryId = kitchen.CategoryId },
            new HighValueItem { Id = Guid.NewGuid(), Name = "Flatware", Value = 500m, CategoryId = kitchen.CategoryId },
            new HighValueItem { Id = Guid.NewGuid(), Name = "Knife Set", Value = 500m, CategoryId = kitchen.CategoryId },
            new HighValueItem { Id = Guid.NewGuid(), Name = "Misc", Value = 1000m, CategoryId = kitchen.CategoryId }
        };

        builder.HasData(initialHighValueItems);
    }
}