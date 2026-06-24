using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public async Task<List<Teacher>> FindAllAsync()
        {
            return await _context.Teachers.Include(p => p.Classrooms).OrderBy(x => x.Name).ToListAsync();
        }
        public async Task InsertAsync(Teacher obj)
        {
            _context.Teachers.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Teacher> FindByIdAsync(int id)
        {
            return await _context.Teachers.Include(p => p.Classrooms).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Teacher obj)
        {
            bool hasAny = await _context.Teachers.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
