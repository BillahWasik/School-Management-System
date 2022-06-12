using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repository.IRepository;

namespace School_Management_System.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public ApplicationDBContext _db;
        public TeacherRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Teacher obj)
        {
            _db.teachers.Update(obj);
        }
    }
}
