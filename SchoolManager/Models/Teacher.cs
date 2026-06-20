using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
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
