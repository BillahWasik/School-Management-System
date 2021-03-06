using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;
using School_Management_System.Repository.IRepository;

namespace School_Management_System.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IunitOfWork db;

        public TeacherController(IunitOfWork _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            IEnumerable<Teacher> e = db.Teacher.GetAll();

            return View(e);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                db.Teacher.Add(obj);
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
            var edit = db.Teacher.Getfirstordefault(u=>u.id==Id);

            if (edit==null)
            {
                return NotFound();
            }

            return View(edit);
        }

        [HttpPost]
        public IActionResult Edit(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                db.Teacher.Update(obj);
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
            var edit = db.Teacher.Getfirstordefault(u => u.id == Id);

            if (edit == null)
            {
                return NotFound();
            }

            return View(edit);
        }

        [HttpPost]
        public IActionResult Delete(Teacher obj)
        {
            
                db.Teacher.Remove(obj);
                db.Save();
                return RedirectToAction("Index");
            
            return View(obj);
        }




    }
}
