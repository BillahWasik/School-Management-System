using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public int roll { get; set; }
        [Required]
        public string section { get; set; }
    }
}
