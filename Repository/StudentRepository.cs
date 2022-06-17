using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repository.IRepository;

namespace School_Management_System.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public ApplicationDBContext _db;
        public StudentRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Student obj)
        {
            _db.students.Update(obj);
        }
    }
}
