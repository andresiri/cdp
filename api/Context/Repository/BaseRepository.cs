using System;
using System.Collections.Generic;
using System.Linq;
using domain.Entities.Enum;
using domain.Entities.Exceptions;
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
            try
            {
                DbSet.Add(obj);
                return obj;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("same key is already being tracked")) {

                    throw new CustomException(ExceptionMessage.DUPLICATE_KEY, ExceptionType.DATABASE_ERROR);
                }

                throw ex;
            }
        }
    }
}