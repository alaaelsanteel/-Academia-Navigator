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
    internal class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.NationalId)
               .HasMaxLength(25);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Level)
                .IsRequired()
                .HasMaxLength(15);

            //many-to-many student <-> course

            builder.HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("Enrollments"));

            //many-to-many student <-> lecture

            builder.HasMany(s => s.Lectures)
                .WithMany(l => l.Students)
                .UsingEntity(j => j.ToTable("Attendances"));
        }
    }
}
