using SM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface ITypeOfRespository
    {
        Task<IEnumerable<TypeOf>> GetTypes();
        Task<TypeOf> GetType(int id);
        Task NewType(TypeOf _type);
        Task<bool> Update(TypeOf _type);
        Task<bool> Delete(int id);
        Task<bool> DeleteAll(int id);
    }
}
