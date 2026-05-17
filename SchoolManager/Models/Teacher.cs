namespace SchoolManager.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

        public Teacher()
        {
        }

        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddClassroom(Classroom c)
        {
            Classrooms.Add(c);
        }
        public void RemoveClassroom(Classroom c)
        {
            Classrooms.Remove(c);
        }


    }
}
