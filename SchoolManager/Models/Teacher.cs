using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Models
{
    public class Teacher
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
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "{0} must contain 10 or 11 digits (with area code) enter numbers only.")]
        public string Phone { get; set; } = string.Empty;
        public ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

        public Teacher()
        {
        }

        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }
        


    }
}
