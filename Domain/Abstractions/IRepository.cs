using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IRepository<T>
    {
        public T GetById(int id);
        public List<T> GetByIds(int[] ids);
        public void Add(T entity);
        public Task<int> GetCountAsync();
    }
}
