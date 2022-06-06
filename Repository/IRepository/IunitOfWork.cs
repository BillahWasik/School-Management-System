﻿namespace School_Management_System.Repository.IRepository
{
    public interface IunitOfWork
    {
        IEmployeeRepository Employee { get; }

        public void Save();
    }
}