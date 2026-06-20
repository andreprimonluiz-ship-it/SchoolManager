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
            Teacher t1 = new Teacher
            {
                Name = "John Smith",
                Email = "john.smith@school.com",
                Phone = "(12) 99111-1111"
            };

            Teacher t2 = new Teacher
            {
                Name = "Maria Silva",
                Email = "maria.silva@school.com",
                Phone = "(12) 99222-2222"
            };

            Teacher t3 = new Teacher
            {
                Name = "Lucas Brown",
                Email = "lucas.brown@school.com",
                Phone = "(12) 99333-3333"
            };

            Teacher t4 = new Teacher
            {
                Name = "Emma Johnson",
                Email = "emma.johnson@school.com",
                Phone = "(12) 99444-4444"
            };

            // Classrooms
            Classroom c1 = new Classroom
            {
                Name = "3A",
                Capacity = 30,
                Shift = Shift.Morning,
                Teacher = t1
            };

            Classroom c2 = new Classroom
            {
                Name = "2B",
                Capacity = 25,
                Shift = Shift.Afternoon,
                Teacher = t2
            };

            Classroom c3 = new Classroom
            {
                Name = "1C",
                Capacity = 20,
                Shift = Shift.Morning,
                Teacher = t3
            };

            Classroom c4 = new Classroom
            {
                Name = "4D",
                Capacity = 35,
                Shift = Shift.Night,
                Teacher = t4
            };

            // Students
            Student s1 = new Student
            {
                Name = "Carlos Oliveira",
                Email = "carlos@email.com",
                Phone = "(12) 99511-1111",
                BirthDate = new DateTime(2008, 3, 15),
                Classroom = c1
            };

            Student s2 = new Student
            {
                Name = "Ana Souza",
                Email = "ana@email.com",
                Phone = "(12) 99522-2222",
                BirthDate = new DateTime(2007, 8, 22),
                Classroom = c1
            };

            Student s3 = new Student
            {
                Name = "Pedro Santos",
                Email = "pedro@email.com",
                Phone = "(12) 99533-3333",
                BirthDate = new DateTime(2008, 1, 10),
                Classroom = c1
            };

            Student s4 = new Student
            {
                Name = "Julia Lima",
                Email = "julia@email.com",
                Phone = "(12) 99544-4444",
                BirthDate = new DateTime(2007, 11, 5),
                Classroom = c2
            };

            Student s5 = new Student
            {
                Name = "Marcos Ferreira",
                Email = "marcos@email.com",
                Phone = "(12) 99555-5555",
                BirthDate = new DateTime(2008, 5, 30),
                Classroom = c2
            };

            Student s6 = new Student
            {
                Name = "Fernanda Costa",
                Email = "fernanda@email.com",
                Phone = "(12) 99566-6666",
                BirthDate = new DateTime(2007, 12, 12),
                Classroom = c2
            };

            Student s7 = new Student
            {
                Name = "Gabriel Alves",
                Email = "gabriel@email.com",
                Phone = "(12) 99577-7777",
                BirthDate = new DateTime(2008, 7, 18),
                Classroom = c3
            };

            Student s8 = new Student
            {
                Name = "Beatriz Rocha",
                Email = "beatriz@email.com",
                Phone = "(12) 99588-8888",
                BirthDate = new DateTime(2008, 9, 2),
                Classroom = c3
            };

            Student s9 = new Student
            {
                Name = "Rafael Martins",
                Email = "rafael@email.com",
                Phone = "(12) 99599-9999",
                BirthDate = new DateTime(2007, 4, 25),
                Classroom = c4
            };

            Student s10 = new Student
            {
                Name = "Camila Pereira",
                Email = "camila@email.com",
                Phone = "(12) 99600-0000",
                BirthDate = new DateTime(2008, 2, 8),
                Classroom = c4
            };

            _context.Teachers.AddRange(t1, t2, t3, t4);
            _context.Classrooms.AddRange(c1, c2, c3, c4);
            _context.Students.AddRange(
                s1, s2, s3, s4, s5,
                s6, s7, s8, s9, s10
            );

            _context.SaveChanges();
        }
    }
}
