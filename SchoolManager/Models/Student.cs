using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "{0} must contain 10 or 11 digits.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public int ClassroomId { get; set; }

        public Classroom Classroom { get; set; }

        public Student()
        {
        }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
