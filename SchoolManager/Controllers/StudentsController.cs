using Microsoft.AspNetCore.Mvc;
using SchoolManager.Services;
using SchoolManager.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManager.Models.ViewModel;
using System.Data;
using SchoolManager.Services.Exceptions;
using System.Diagnostics;

namespace SchoolManager.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsService _studentsService;
        private readonly ClassroomService _classroomService;
        public StudentsController(StudentsService studentsService, ClassroomService classroomService)
        {
            _studentsService = studentsService;
            _classroomService = classroomService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _studentsService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var classrooms = await _classroomService.FindAllAsync();
            var viewModel = new StudentFormViewModel { Classrooms = classrooms };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                var classes = await _classroomService.FindAllAsync();
                var viewModel = new StudentFormViewModel { Student = student, Classrooms = classes };
                return View(viewModel);
            }
            await _studentsService.InsertAsync(student);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _studentsService.FindByIdAsync(id.Value);
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
            await _studentsService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _studentsService.FindByIdAsync(id.Value);
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
            var obj = await _studentsService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Classroom> classes = await _classroomService.FindAllAsync();
            StudentFormViewModel viewModel = new StudentFormViewModel() { Student = obj, Classrooms = classes };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                var classes = await _classroomService.FindAllAsync();
                var viewModel = new StudentFormViewModel { Student = student, Classrooms = classes };
                return View(viewModel);
            }

            if (id != student.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _studentsService.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }


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
