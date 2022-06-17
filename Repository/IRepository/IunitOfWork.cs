namespace School_Management_System.Repository.IRepository
{
    public interface IunitOfWork
    {
        IEmployeeRepository Employee { get; }
        ITeacherRepository Teacher { get; }

        IStudentRepository Student { get; }

        public void Save();
    }
}
