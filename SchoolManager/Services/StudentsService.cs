using SchoolManager.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Services.Exceptions;

namespace SchoolManager.Services
{
    public class StudentsService
    {
        private readonly SchoolManagerContext _context;

        public StudentsService (SchoolManagerContext context)
        {
            _context = context;
        }

        public List<Student> FindAll()
        {
            return _context.Students.Include(p => p.Classroom).ToList();
        }
        public void Insert(Student obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Student FindById(int id)
        {
            return _context.Students.Include(p => p.Classroom).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Students.Find(id);
            _context.Students.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Student obj)
        {
            if (!_context.Students.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
