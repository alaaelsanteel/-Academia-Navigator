using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker.Repository.Data.Config
{
    internal class ProfessorConfigurations : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(p => p.NationalId)
                .HasMaxLength(25);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
