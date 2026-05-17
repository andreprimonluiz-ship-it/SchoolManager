using SchoolManager.Models;
using SchoolManager.Models.Enums;

namespace SchoolManager.Data
{
    public class SeedingService
    {
        private readonly SchoolManagerContext _context;

        public SeedingService(SchoolManagerContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Classrooms.Any() ||
                _context.Students.Any() ||
                _context.Teachers.Any())
            {
                return;
            }

            // Teachers
            Teacher t1 = new Teacher(1, "John Smith");
            Teacher t2 = new Teacher(2, "Maria Silva");
            Teacher t3 = new Teacher(3, "Lucas Brown");
            Teacher t4 = new Teacher(4, "Emma Johnson");

            // Classrooms
            Classroom c1 = new Classroom(1, "3A", 30, Shift.Morning);
            Classroom c2 = new Classroom(2, "2B", 25, Shift.Afternoon);
            Classroom c3 = new Classroom(3, "1C", 20, Shift.Morning);
            Classroom c4 = new Classroom(4, "4D", 35, Shift.Night);

            // Classroom -> Teacher
            c1.Teacher = t1;
            c2.Teacher = t2;
            c3.Teacher = t3;
            c4.Teacher = t4;

            // Students
            Student s1 = new Student(1, "Carlos");
            Student s2 = new Student(2, "Ana");
            Student s3 = new Student(3, "Pedro");
            Student s4 = new Student(4, "Julia");
            Student s5 = new Student(5, "Marcos");
            Student s6 = new Student(6, "Fernanda");
            Student s7 = new Student(7, "Gabriel");
            Student s8 = new Student(8, "Beatriz");
            Student s9 = new Student(9, "Rafael");
            Student s10 = new Student(10, "Camila");

            // Student -> Classroom
            s1.Classroom = c1;
            s2.Classroom = c1;
            s3.Classroom = c1;

            s4.Classroom = c2;
            s5.Classroom = c2;
            s6.Classroom = c2;

            s7.Classroom = c3;
            s8.Classroom = c3;

            s9.Classroom = c4;
            s10.Classroom = c4;

            // Save Teachers
            _context.Teachers.AddRange(
                t1, t2, t3, t4
            );

            // Save Classrooms
            _context.Classrooms.AddRange(
                c1, c2, c3, c4
            );

            // Save Students
            _context.Students.AddRange(
                s1, s2, s3, s4, s5,
                s6, s7, s8, s9, s10
            );

            _context.SaveChanges();
        }
    }
}
