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
    internal class DrinksConfigration : IEntityTypeConfiguration<Drinks>
    {
        public void Configure(EntityTypeBuilder<Drinks> builder)
        {
            builder.Property(d => d.Name).HasMaxLength(50);
            builder.HasIndex(d => d.Name).IsUnique();

        }
    }
}
