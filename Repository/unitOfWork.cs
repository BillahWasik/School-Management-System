using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repository.IRepository;

namespace School_Management_System.Repository
{
    public class unitOfWork : IunitOfWork
    {
        private readonly ApplicationDBContext _db;

        public unitOfWork(ApplicationDBContext db)
        {
            _db = db;


            Employee = new EmployeeRepository(_db);

            Teacher = new TeacherRepository(_db);

            Student = new StudentRepository(_db);
        }
        public IEmployeeRepository Employee { get; private set; }

        public ITeacherRepository Teacher { get; private set; }

        public IStudentRepository Student { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
