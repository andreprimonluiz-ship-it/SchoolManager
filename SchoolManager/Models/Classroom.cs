using SchoolManager.Models.Enums;
namespace SchoolManager.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Shift Shift { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public Classroom() { }

        public Classroom(int id, string name, int capacity, Shift shift)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            Shift = shift;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
        public string SearchStudent(string nome)
        {
            return Students.Where(p => p.Nome == nome).Select(p => p.Nome).FirstOrDefault();
        }
        


    }
}
