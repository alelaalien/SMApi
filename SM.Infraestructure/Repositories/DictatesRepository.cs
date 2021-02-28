using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.Infraestructure.Repositories
{
    public class DictatesRepository
    {
        //private readonly SMContext _context; : IDictatesRepository 
        //protected readonly DbSet<Dictates> _entities;


        //public DictatesRepository(SMContext sm)
        //{
        //    _context = sm;
        //}
  
        //public  async Task<bool> Delete(IEnumerable<Dictates> a)
        //{

        //    _context.RemoveRange(a);
        //    int rows = await _context.SaveChangesAsync();
        //    return rows > 0;
        //}

        //public IEnumerable<Dictates> GetDictates()
        //{
        //    return _entities.AsEnumerable();
        //}

        //public async Task NewDictates(Dictates _dictates)
        //{
        //    _context.Dictates.Add(_dictates);
        //    await _context.SaveChangesAsync();
        //}

        //public void Dispose()
        //{
        //    if (_context != null)
        //    {
        //        _context.Dispose();
        //    }
        //}

        //public void SaveChanges()
        //{
        //    _context.SaveChanges();
        //}

        //public async Task SaveChangesAsync()
        //{
        //    await _context.SaveChangesAsync();
        //}

        //Task<IEnumerable<Dictates>> IDictatesRepository.GetDictates()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
