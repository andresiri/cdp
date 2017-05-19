using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Context.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        internal CdpContext _context;
        internal DbSet<T> DbSet;

        public BaseRepository(CdpContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual T Create(T obj)
        {     
            DbSet.Add(obj);      
            return obj;         
        }
    }
}