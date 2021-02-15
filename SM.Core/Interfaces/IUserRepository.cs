using SM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetLoginByCredentials(CommonLogin login);
    }
}
