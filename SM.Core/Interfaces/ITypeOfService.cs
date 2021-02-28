using SM.Core.Entities;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
   public interface ITypeOfService
    {
        IEnumerable<TypeOf> GetTypes(TypeQueryFilters filters);
        Task<TypeOf> GetType(int id);
        Task NewType(TypeOf _type);
        Task<bool> Update(TypeOf _type);
        Task<bool> Delete(int id);
        Task<bool> DeleteAll(TypeQueryFilters filters);
    }
}
