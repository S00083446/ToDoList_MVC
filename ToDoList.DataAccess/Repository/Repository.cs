using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;

namespace ToDoList.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;                                                                                                                                                                                                                               
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _db.MoreDetails.Include(u => u.Detail);//.Include(u => u.Subjects); //only for ApplicationDB Context
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
            //throw new NotImplementedException();
        }

        //includeProp - "Category, Subjects", exact case
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp); 
                }
            }
            //if (filter != null)
            //{
            //    query = query.Where(filter);
            //}
            //if (includeProperties != null)
            //{
            //    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        query = query.Include(includeProp);
            //    }
            //}
            return query.ToList();
            //throw new NotImplementedException();
        }

     
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            //if (tracked)
            //{
                IQueryable<T> query = dbSet;

                query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            //if (includeProperties != null)
            //{
            //    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        query = query.Include(includeProp);
            //    }
            //}
            return query.FirstOrDefault();
            //}
            //else
            //{
            //    IQueryable<T> query = dbSet.AsNoTracking();

            //    query = query.Where(filter);
            //    if (includeProperties != null)
            //    {
            //        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //        {
            //            query = query.Include(includeProp);
            //        }
            //    }
            //    return query.FirstOrDefault();
            //}

        }

        
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            //throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            //throw new NotImplementedException();
        }

    }
}
