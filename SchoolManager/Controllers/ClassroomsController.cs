
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Models;
using SchoolManager.Models.ViewModel;
using SchoolManager.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ClassroomsController : Controller
{
    private readonly SchoolManagerContext _context;
    private readonly TeacherService _teacherService;
    private readonly ClassroomService _classroomService;

    public ClassroomsController(SchoolManagerContext context, TeacherService teacherService, ClassroomService classroomService)
    {
        _context = context;
        _teacherService = teacherService;
        _classroomService = classroomService;
    }

    // GET: CLASSROOMS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Classrooms.ToListAsync());
    }

    // GET: CLASSROOMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classrooms
            .FirstOrDefaultAsync(m => m.Id == id);
        if (classroom == null)
        {
            return NotFound();
        }

        return View(classroom);
    }

    // GET: CLASSROOMS/Create
    public async Task<IActionResult> Create()
    {
        var teachers = await _teacherService.FindAllAsync();
        var viewModel = new ClassroomFormViewModel { Teachers = teachers };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Classroom classroom)
    {
        if (!ModelState.IsValid)
        {
            var teachers = await _teacherService.FindAllAsync();
            var viewModel = new ClassroomFormViewModel { Teachers = teachers, Classroom = classroom };
            return View(viewModel);
        }
        await _classroomService.InsertAsync(classroom);
        return RedirectToAction(nameof(Index));
    }

    // GET: CLASSROOMS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided" });
        }
        var obj = await _classroomService.FindByIdAsync(id.Value);
        if (obj == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not found" });
        }

        List<Teacher> classes = await _teacherService.FindAllAsync();
        ClassroomFormViewModel viewModel = new ClassroomFormViewModel() { Classroom = obj, Teachers = classes };
        return View(viewModel);
    }

    // POST: CLASSROOMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Capacity,Shift,TeacherId")] Classroom classroom)
    {
        if (id != classroom.Id)
        {
            return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
        }
        try
        {
            await _classroomService.UpdateAsync(classroom);
            return RedirectToAction(nameof(Index));
        }
        catch (ApplicationException e)
        {
            return RedirectToAction(nameof(Error), new { message = e.Message });
        }
    }

    // GET: CLASSROOMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classrooms
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
        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom != null)
        {
            _context.Classrooms.Remove(classroom);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClassroomExists(int? id)
    {
        return _context.Classrooms.Any(e => e.Id == id);
    }
}
