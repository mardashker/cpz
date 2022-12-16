using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Models
{
    public class UniversityTask
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Time { get; set; }

        public int Priority { get; set; }

        public string Status { get; set; }
    }
}
