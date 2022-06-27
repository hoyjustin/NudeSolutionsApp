using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NudeApp.Models;
using System;
using System.Collections.Generic;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public static IEnumerable<Category> initialCategories = new List<Category>{
        new Category { CategoryId = Guid.NewGuid(), Name = "None" },
        new Category { CategoryId = Guid.NewGuid(), Name = "Electronics" },
        new Category { CategoryId = Guid.NewGuid(), Name = "Clothing" },
        new Category { CategoryId = Guid.NewGuid(), Name = "Kitchen" }
    };

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.CategoryId);
        builder.HasData(initialCategories);
    }
}