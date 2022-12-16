using Student.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        void Save();
    }
    }
