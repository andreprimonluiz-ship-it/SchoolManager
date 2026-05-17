namespace SchoolManager.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Classroom Classroom { get; set; }

        public Student() { }

        public Student(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
