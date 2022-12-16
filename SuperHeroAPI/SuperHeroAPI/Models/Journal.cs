using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Models
{
    public class Journal
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ExamMark { get; set; }

        public int VisitPercentage { get; set; }
    }
}
