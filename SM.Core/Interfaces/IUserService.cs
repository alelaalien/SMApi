using SM.Core.Entities;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(UserQueryFilters filters);
        Task<User> GetUser(int id);
        Task NewUser(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
        Task<User> GetLoginByCredentials(CommonLogin login);

    }
}
