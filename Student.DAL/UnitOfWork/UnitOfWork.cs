using Student.DAL.IRepository;
using Student.DAL.Repository;
using Student.Domin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private readonly StudentDbContext _context;

        public UnitOfWork(StudentDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

