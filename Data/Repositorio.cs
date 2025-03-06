using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Data
{
    public interface IRepositorio<T>
    {
        IQueryable<T> get { get;}

        void add(T item);

        void update(T item);

        void delete(T item);

        Task saveChangesAsync();
    }
    public class Repositorio<T> : IRepositorio<T>
        where T : class
    {
 
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repositorio(AppDbContext dbContext)
        {   
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
           // _dbSet = _dbContext.GetType()
           //.GetProperties()
           //.Where(p => p.PropertyType == typeof(DbSet<T>))
           //.Select(p => p.GetValue(_dbContext) as DbSet<T>)
           //.FirstOrDefault();
        }

        public virtual async Task saveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual void add(T item)
        {
            _dbSet.Add(item);
        }

        public virtual void delete(T item)
        {
            _dbSet.Remove(item);
        }



        public virtual IQueryable<T> get
        {
            get { return _dbSet.AsNoTracking(); }
        }



        public virtual void update(T item)
        {
            _dbSet.Entry(item).State = EntityState.Modified;
        }
    }
}
