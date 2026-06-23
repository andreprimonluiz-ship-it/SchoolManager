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

        public async Task<List<Student>> FindAllAsync()
        {
            return await _context.Students.Include(p => p.Classroom).OrderBy(x => x.Classroom.Shift).ToListAsync();
        }
        public async Task InsertAsync(Student obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Student> FindByIdAsync(int id)
        {
            return await _context.Students.Include(p => p.Classroom).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Students.FindAsync(id);
            _context.Students.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Student obj)
        {
            bool hasAny = await _context.Students.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
