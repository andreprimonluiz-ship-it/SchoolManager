using Microsoft.EntityFrameworkCore;
using SchoolManager.Models;
using SchoolManager.Services.Exceptions;

namespace SchoolManager.Services
{
    public class TeacherService
    {

        private readonly SchoolManagerContext _context;
        public TeacherService(SchoolManagerContext context)
        {
            _context = context;
        }

        public List<Teacher> FindAll()
        {
            return _context.Teachers.Include(p => p.Classrooms).ToList();
        }
        public void Insert(Teacher obj)
        {
            _context.Teachers.Add(obj);
            _context.SaveChanges();
        }
        public Teacher FindById(int id)
        {
            return _context.Teachers.FirstOrDefault(p => p.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Teachers.Find(id);
            _context.Teachers.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Teacher obj)
        {
            if (!_context.Teachers.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
