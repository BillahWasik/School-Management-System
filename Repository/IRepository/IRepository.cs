﻿using System.Linq.Expressions;

namespace School_Management_System.Irepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T item);

        void Remove(T item);

        T Getfirstordefault(Expression<Func<T,bool>>filter);
    }
}
