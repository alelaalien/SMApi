using SM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IDictatesRepository 
    {
        Task<IEnumerable<Dictates>>  GetDictates();
        Task NewDictates(Dictates d);
        Task<bool> Delete(IEnumerable<Dictates> d);
 
    }
}
