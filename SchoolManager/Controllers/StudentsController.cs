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
            if (!ModelState.IsValid)
            {
                var classes = _classroomService.FindAll();
                var viewModel = new StudentFormViewModel { Student = student, Classrooms = classes };
                return View(viewModel);
            }
            _studentsService.Insert(student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _studentsService.FindById(id.Value);
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
            _studentsService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _studentsService.FindById(id.Value);
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
            var obj = _studentsService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Classroom> classes = _classroomService.FindAll();
            StudentFormViewModel viewModel = new StudentFormViewModel() { Student = obj, Classrooms = classes };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                var classes = _classroomService.FindAll();
                var viewModel = new StudentFormViewModel { Student = student, Classrooms = classes };
                return View(viewModel);
            }

            if (id != student.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _studentsService.Update(student);
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
