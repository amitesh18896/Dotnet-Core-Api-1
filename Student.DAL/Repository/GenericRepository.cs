using Microsoft.EntityFrameworkCore;
using Student.DAL.IRepository;
using Student.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Student.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DbSet<TEntity> dbSet;
        internal StudentDbContext context;
        public GenericRepository(StudentDbContext _context)
        {
            context = _context;
            dbSet = _context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }
        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        //public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = dbSet;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperties);
        //    }
        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);

        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return dbSet.ToList();
        }

        //public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = dbSet;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperties);
        //    }
        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
    }
        }
    

