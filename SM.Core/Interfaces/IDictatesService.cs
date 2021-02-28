using SM.Core.Entities;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IDictatesService  
    {
   
            IEnumerable<Dictates> GetDictates(DictatesQueryFilters filters);
            Task NewDictates(Dictates _dictates); 
            Task<bool> Delete(DictatesQueryFilters filters); 
     
    }
}
