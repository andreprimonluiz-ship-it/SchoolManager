namespace SchoolManager.Models.ViewModel
{
    public class ClassroomFormViewModel
    {
        public Classroom Classroom { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
