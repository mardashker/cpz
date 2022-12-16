using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperHeroAPI;
using SuperHeroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedStudents(modelBuilder.Entity<Student>());
            SeedJournal(modelBuilder.Entity<Journal>());
        }

        public static void SeedStudents(EntityTypeBuilder<Student> entityTypeBuilder)
        {
            entityTypeBuilder.HasData(new Student
            {
                Id = 1,
                Name = "Name1",
                Group = "PZ-34"
            },
            new Student
            {
                Id = 2,
                Name = "Name2",
                Group = "PZ-31"
            });
        }

        public static void SeedJournal(EntityTypeBuilder<Journal> entityTypeBuilder)
        {
            entityTypeBuilder.HasData(new Journal
            {
                Id = 1,
                StudentId = 1,
                ExamMark = 100,
                VisitPercentage = 50
            },
            new Journal
            {
                Id = 2,
                StudentId = 2,
                ExamMark = 100,
                VisitPercentage = 40
            });
        }
    }
}
