﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker.Repository.Data.Config
{
    internal class LectureConfigurations : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.Property(p => p.Day)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(p => p.StartTime)
                .HasColumnType("time")
                   .IsRequired();

            builder.Property(p => p.EndTime)
                .HasColumnType("time")
                   .IsRequired();

            builder.Property(p => p.Date)
                .IsRequired(false);

            builder.Property(p => p.ProfessorNationalId)
                  .IsRequired(false);

            builder.Property(p => p.HallId)
                  .IsRequired();

            builder.Property(p => p.OriginalLectureId)
                .IsRequired();

            //many-to-one lecture <-> course
            builder.HasOne(p => p.Course)
                .WithMany(c => c.Lectures)
                .HasForeignKey(l => l.CourseId);

            //many-to-one lecture <-> professor
            builder.HasOne(p => p.Professor)
                .WithMany(c => c.Lectures)
                .HasForeignKey(l => l.ProfessorNationalId)
                .OnDelete(DeleteBehavior.SetNull);

            //many-to-one lecture <-> hall
            builder.HasOne(p => p.Hall)
                .WithMany(h => h.Lectures)
                .HasForeignKey(l => l.HallId);

            //many-to-one lecture <-> lecture self ref
            builder.HasOne(p => p.OriginalLecture)
                .WithMany()
                .HasForeignKey(p => p.OriginalLectureId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
