using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroAPI.Models
{
    [Table("StudentTask")]
    public class StudentTask
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int UniversityTaskId { get; set; }
        public UniversityTask UniversityTask { get; set; }

        public int Mark { get; set; }
    }
}
