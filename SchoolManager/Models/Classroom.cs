using SchoolManager.Models.Enums;
namespace SchoolManager.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Shift Shift { get; set; }
    }
}
