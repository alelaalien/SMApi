using SM.Core.Entities;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface ISecurityRepository: IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
     
    }
}
