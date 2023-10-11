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
    internal class EmployeeConfigration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Address).HasMaxLength(70);
            builder.Property(e => e.JobDescription).HasMaxLength(50);
            builder.Property(e => e.PhoneNumber).HasColumnType("char").HasMaxLength(11);

        }
    }
}
