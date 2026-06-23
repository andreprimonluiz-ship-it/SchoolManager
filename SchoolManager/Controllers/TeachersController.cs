using Microsoft.AspNetCore.Mvc;
using SchoolManager.Models;
using SchoolManager.Models.ViewModel;
using SchoolManager.Services;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace SchoolManager.Controllers
{
    public class TeachersController : Controller
    {
        private readonly TeacherService _teacherService;
        private readonly ClassroomService _classroomService;

        public TeachersController(TeacherService teacherService, ClassroomService classroomService)
        {
            _teacherService = teacherService;
            _classroomService = classroomService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _teacherService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var classrooms = await _classroomService.FindAllAsync();
            var viewModel = new TeacherFormViewModel { Classrooms = classrooms };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            await _teacherService.InsertAsync(teacher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _teacherService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _teacherService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _teacherService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            await _teacherService.UpdateAsync(teacher);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier

            };
            return View(viewModel);
        }




    }
}
