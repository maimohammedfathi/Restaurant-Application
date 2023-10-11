using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOfProject.Entity;

namespace VersionOfProject.Cofigration
{
    public class CategoryFoodConfigration : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> builder)
        {
            builder.HasIndex(u => u.Name).IsUnique();
            builder.Property(u => u.Name).HasMaxLength(50);
        }
    }
}
