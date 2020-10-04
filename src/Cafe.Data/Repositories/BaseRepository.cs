using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cafe.Data.Context;
using Cafe.Data.Models.Models;
using Cafe.Data.Repositories.Abstract;

namespace Cafe.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity, new()
    {
        protected readonly MainContext db;

        public BaseRepository(MainContext context)
        {
            db = context;
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            db.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            T obj = GetById(entity.Id);
            
            if (obj != null)
            {
                db.Set<T>().Remove(obj);
            }
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            T obj = db.Set<T>().FirstOrDefault(predicate);
            
            if (obj != null)
            {
                db.Set<T>().Remove(obj);
            }
        }

        public T GetById(int id)
        {
            return db.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().FirstOrDefault(predicate); 
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }
        
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate); 
        }

        public int Count()
        {
            return db.Set<T>().Count();
        }

        public void Commit()
        {
            db.SaveChanges();
        }
    }
}