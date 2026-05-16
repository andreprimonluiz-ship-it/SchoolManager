
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Models;

public class ClassroomsController : Controller
{
    private readonly SchoolManagerContext _context;

    public ClassroomsController(SchoolManagerContext context)
    {
        _context = context;
    }

    // GET: CLASSROOMS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Classroom.ToListAsync());
    }

    // GET: CLASSROOMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classroom
            .FirstOrDefaultAsync(m => m.Id == id);
        if (classroom == null)
        {
            return NotFound();
        }

        return View(classroom);
    }

    // GET: CLASSROOMS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CLASSROOMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Capacity,Shift")] Classroom classroom)
    {
        if (ModelState.IsValid)
        {
            _context.Add(classroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(classroom);
    }

    // GET: CLASSROOMS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classroom.FindAsync(id);
        if (classroom == null)
        {
            return NotFound();
        }
        return View(classroom);
    }

    // POST: CLASSROOMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Capacity,Shift")] Classroom classroom)
    {
        if (id != classroom.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(classroom);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(classroom.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(classroom);
    }

    // GET: CLASSROOMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classroom
            .FirstOrDefaultAsync(m => m.Id == id);
        if (classroom == null)
        {
            return NotFound();
        }

        return View(classroom);
    }

    // POST: CLASSROOMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var classroom = await _context.Classroom.FindAsync(id);
        if (classroom != null)
        {
            _context.Classroom.Remove(classroom);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClassroomExists(int? id)
    {
        return _context.Classroom.Any(e => e.Id == id);
    }
}
