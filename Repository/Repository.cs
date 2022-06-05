using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Irepository;
using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;

        public DbSet<T> dbset { get; set; }

        public Repository(ApplicationDBContext db)
        {
            _db = db;
            this.dbset= _db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> data = dbset;

            return data.ToList();
        }

        public void Add(T item)
        {
           dbset.Add(item);
        }

        public void Remove(T item)
        {
            dbset.Remove(item);
        }

        public T Getfirstordefault(Expression<Func<T, bool>> filter)
        {
            IQueryable <T> data = dbset;

            data=data.Where(filter);

            return data.FirstOrDefault();
        }
    }
}
