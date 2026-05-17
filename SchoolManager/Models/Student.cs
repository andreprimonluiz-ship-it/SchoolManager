namespace SchoolManager.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

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
