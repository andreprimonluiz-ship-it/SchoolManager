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

        public async Task<List<Classroom>> FindAllAsync()
        {
           return await _context.Classrooms.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Classroom> FindByIdAsync(int id)
        {
            return await _context.Classrooms.FirstOrDefaultAsync(c => id == c.Id);
        }
             
        public async Task InsertAsync(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Classroom obj)
        {

            bool hasAny = await _context.Classrooms.AnyAsync(x => x.Id == obj.Id);
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
