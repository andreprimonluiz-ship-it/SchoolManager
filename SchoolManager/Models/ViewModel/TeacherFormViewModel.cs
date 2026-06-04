namespace SchoolManager.Models.ViewModel
{
    public class TeacherFormViewModel
    {
        public Teacher Teacher { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
    }
}
