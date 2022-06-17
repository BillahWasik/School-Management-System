using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;
using School_Management_System.Repository.IRepository;

namespace School_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IunitOfWork db;

        public StudentController(IunitOfWork _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> e = db.Student.GetAll();

            return View(e);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(obj);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var edit = db.Student.Getfirstordefault((System.Linq.Expressions.Expression<Func<Student, bool>>)(u=> u.id == Id));

            if (edit==null)
            {
                return NotFound();
            }

            return View(edit);
        }

        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                db.Student.Update(obj);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var edit = db.Student.Getfirstordefault((System.Linq.Expressions.Expression<Func<Student, bool>>)(u => u.id == Id));

            if (edit == null)
            {
                return NotFound();
            }

            return View(edit);
        }

        [HttpPost]
        public IActionResult Delete(Student obj)
        {
            
                db.Student.Remove(obj);
                db.Save();
                return RedirectToAction("Index");
            
            return View(obj);
        }




    }
}
