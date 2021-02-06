using SM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task NewUser(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
    }
}
