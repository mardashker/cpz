using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students => Set<Student>();
        public DbSet<UniversityTask> UniversityTasks => Set<UniversityTask>();
        public DbSet<Journal> Journals => Set<Journal>();
        public DbSet<StudentTask> StudentTasks => Set<StudentTask>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new StudentConfiguration());
            //modelBuilder.ApplyConfiguration(new SickHistoryConfiguration());
            DAL.SeedData.Seed(modelBuilder);
        }
    }


}
