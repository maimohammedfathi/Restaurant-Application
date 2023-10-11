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
    internal class FoodConfigration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(d => d.Name).HasMaxLength(50);
            builder.HasIndex(f => f.Name).IsUnique();


        }
    }
}
