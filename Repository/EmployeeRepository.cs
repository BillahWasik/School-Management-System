using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repository.IRepository;

namespace School_Management_System.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public ApplicationDBContext _db;
        public EmployeeRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
           _db.SaveChanges();
        }

        public void Update(Employee obj)
        {
           _db.employees.Update(obj);
        }
    }
}
