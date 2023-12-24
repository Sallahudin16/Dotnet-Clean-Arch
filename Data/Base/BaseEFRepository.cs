using Data;
using Data.Exceptions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class BaseEFRepository<T> : IRepository<T>
        where T : class //Shouold be Aggregate Root
    {
        protected readonly ExpressContext _context;

        public BaseEFRepository(ExpressContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if(entity == null)
            {
                throw new EntityNotFound($"Entity with key {id} was not found");
            }

            return entity;
        }

        public List<T> GetByIds(int[] ids)
        {
            var result = new List<T>();
            foreach (var id in ids)
            {
                var entity = _context.Set<T>().Find(id);
                if(entity != null)
                    result.Add(entity);
            }
            return result;
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}
