using School_Management_System.Irepository;
using School_Management_System.Models;

namespace School_Management_System.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {

        void Update(Employee obj);

        void Save();
    }
}
