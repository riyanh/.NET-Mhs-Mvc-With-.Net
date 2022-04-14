﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MhsMVCWeb.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Age")]
        [Range(1,100,ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }
        public string Adress { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
