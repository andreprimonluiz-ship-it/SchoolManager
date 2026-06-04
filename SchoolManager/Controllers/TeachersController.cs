using Microsoft.AspNetCore.Mvc;
using SchoolManager.Models;
using SchoolManager.Models.ViewModel;
using SchoolManager.Services;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace SchoolManager.Controllers
{
    public class TeachersController: Controller
    {
        private readonly TeacherService _teacherService;
        private readonly ClassroomService _classroomService;

        public TeachersController (TeacherService teacherService, ClassroomService classroomService)
        {
            _teacherService = teacherService;
            _classroomService = classroomService;
        }

        public IActionResult Index()
        {
            var list = _teacherService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var classrooms = _classroomService.FindAll();
            var viewModel = new TeacherFormViewModel { Classrooms = classrooms};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            _teacherService.Insert(teacher);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _teacherService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
                return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _teacherService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _teacherService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _teacherService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {
            _teacherService.Update(teacher);
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
