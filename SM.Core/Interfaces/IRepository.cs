using SM.Core.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T t);
        Task Delete(int id);
        Task DeleteAll(IEnumerable<T> a);
        Task Add(T t);

    }
}
