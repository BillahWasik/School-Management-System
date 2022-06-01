using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int salary { get; set; }

        public string role { get; set; }
    }
}
