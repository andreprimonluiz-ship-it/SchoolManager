using Microsoft.AspNetCore.Mvc;
using SchoolManager.Services;
using SchoolManager.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManager.Models.ViewModel;

namespace SchoolManager.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsService _studentsService;
        private readonly ClassroomService _classroomService;
        public StudentsController (StudentsService studentsService, ClassroomService classroomService)
        {
            _studentsService = studentsService;
            _classroomService = classroomService;
        }

        public IActionResult Index()
        {
            var list = _studentsService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var classrooms = _classroomService.FindAll();
            var viewModel = new StudentFormViewModel { Classrooms = classrooms };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            _studentsService.Insert(student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _studentsService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _studentsService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _studentsService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

    }
}
