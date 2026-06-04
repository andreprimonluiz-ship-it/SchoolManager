using Microsoft.EntityFrameworkCore;
using SchoolManager.Models;
using SchoolManager.Services.Exceptions;

namespace SchoolManager.Services
{
    public class ClassroomService
    {
        private readonly SchoolManagerContext _context;

        public ClassroomService(SchoolManagerContext context)
        {
            _context = context;
        }

        public List<Classroom> FindAll()
        {
           return _context.Classrooms.OrderBy(x => x.Name).ToList();
        }

        public Classroom FindById(int id)
        {
            return _context.Classrooms.FirstOrDefault(c => id == c.Id);
        }
             
        public void Insert(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
        }

        public void Update(Classroom obj)
        {
            if (!_context.Classrooms.Any(x => x.Id == obj.Id))
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
