using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.Core.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _userR;
        public UserService(IUnitOfWork userRepository)
        {
            _userR = userRepository;
        }

        public async Task<bool> Delete(int id)
        {
         await _userR.UserRepository.Delete(id);
            await _userR.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUser(int id)
        {
          return  await _userR.UserRepository.GetById(id);
        }

        public  IEnumerable<User> GetUsers(UserQueryFilters filters)
        {
            var users= _userR.UserRepository.GetAll();
            if (filters.Id != null) { users = users.Where(x => x.Id == filters.Id); }
            if (filters.Nick != null) { users = users.Where(x => x.Nick.ToLower() == filters.Nick.ToLower()); }
            if (filters.Email != null) { users = users.Where(x => x.Email.ToLower() == filters.Email.ToLower()); }

            return users;
        }

        public async Task NewUser(User user)
        {
            await _userR.UserRepository.Add(user);
            await _userR.SaveChangesAsync();

        }

        public async Task<bool> Update(User user)
        {
             _userR.UserRepository.Update(user);
            await _userR.SaveChangesAsync();
            return true;
        }
    }
}
