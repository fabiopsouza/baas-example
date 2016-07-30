using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using tcc.core.repository.Context;
using tcc.core.repository.Interfaces;

namespace tcc.core.repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppContext Ctx = new AppContext();
        
        public void Create(T obj)
        {
            Ctx.Set<T>().Add(obj);
            Ctx.SaveChanges();
        }

        public void CreateRange(IList<T> list)
        {
            Ctx.Set<T>().AddRange(list);
            Ctx.SaveChanges();
        }

        public void Update(T obj)
        {
            Ctx.Entry(obj).State = EntityState.Modified;
            Ctx.SaveChanges();
        }

        public void Remove(T obj)
        {
            Ctx.Set<T>().Remove(obj);
            Ctx.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return Ctx.Set<T>().ToList();
        }

        public IList<T> Get(Expression<Func<T, bool>> filter)
        {
            return Ctx.Set<T>().Where(filter).ToList();
        }
    }
}
