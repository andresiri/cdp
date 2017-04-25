using System.Collections.Generic;
using System.Linq;
using domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Context.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        protected CdpContext _context;
        protected DbSet<T> DbSet;

        public BaseRepository(CdpContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Create(T obj)
        {
            _context.Set<T>().Add(obj);
            return obj;
        }
    }
}