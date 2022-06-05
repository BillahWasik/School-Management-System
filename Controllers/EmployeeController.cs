using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;
using School_Management_System.Repository.IRepository;

namespace School_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository db;

        public EmployeeController(IEmployeeRepository _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> e = db.GetAll();

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
                db.Add(obj);
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
            var edit = db.Getfirstordefault(u=>u.id==Id);

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
                db.Update(obj);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }




    }
}
