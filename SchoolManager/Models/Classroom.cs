
using SchoolManager.Models.Enums;
using System.ComponentModel.DataAnnotations;
namespace SchoolManager.Models
{
    public class Classroom
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [RegularExpression(@"^\d+[A-Z]$", ErrorMessage = "Use the 10A format (number + uppercase letter).")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(10, 35, ErrorMessage = "The capacity should be between 10 and 35 students.")]
        public int Capacity { get; set; }

        public Shift Shift { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public Teacher Teacher { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public Classroom() { }

        public Classroom(int id, string name, int capacity, Shift shift)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            Shift = shift;
        }





    }
}
