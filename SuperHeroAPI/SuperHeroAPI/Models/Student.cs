﻿using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Group { get; set; }
    }
}
