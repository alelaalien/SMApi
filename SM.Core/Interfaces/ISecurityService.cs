using SM.Core.Entities;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
        Task Register(Security security);
    }
}
