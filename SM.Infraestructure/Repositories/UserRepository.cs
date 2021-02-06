using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Infraestructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        private SMContext _context;
        public UserRepository(SMContext sm)
        {
            _context = sm;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var Users = await _context.User.ToListAsync()
; return Users;
        }
        public async Task<User> GetUser(int id)
        {
            var User = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            return User;
        }
        public async Task NewUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> Update(User _user)
        {
            var currUser = await GetUser(_user.Id);
            currUser.Nick = _user.Nick;
            currUser.Email = _user.Email;
            currUser.Img = _user.Img;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var currUser = await GetUser(id);
            _context.User.Remove(currUser);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }

    }
}
