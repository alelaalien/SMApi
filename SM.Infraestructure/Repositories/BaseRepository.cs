using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SMContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(SMContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T t)
        {
           await _entities.AddAsync(t);

        }

        public async Task Delete(int id)
        {
            var currT = await GetById(id);
            _entities.Remove(currT);
 
        }
        public void Update(T t)
        {
            _entities.Update(t);

        }
 

        public async Task DeleteAll(IEnumerable<T> a)
        {

               _entities.RemoveRange(a); 
        }
    }
}
