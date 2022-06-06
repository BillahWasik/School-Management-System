using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;
using School_Management_System.Repository.IRepository;

namespace School_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IunitOfWork db;

        public EmployeeController(IunitOfWork _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> e = db.Employee.GetAll();

            return View(e);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(obj);
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
            var edit = db.Employee.Getfirstordefault(u=>u.id==Id);

            if (edit==null)
            {
                return NotFound();
            }

            return View(edit);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Update(obj);
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
            var edit = db.Employee.Getfirstordefault(u => u.id == Id);

            if (edit == null)
            {
                return NotFound();
            }

            return View(edit);
        }

        [HttpPost]
        public IActionResult Delete(Employee obj)
        {
            
                db.Employee.Remove(obj);
                db.Save();
                return RedirectToAction("Index");
            
            return View(obj);
        }




    }
}
