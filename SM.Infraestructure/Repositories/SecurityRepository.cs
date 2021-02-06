
using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Data;
using System.Threading.Tasks;
namespace SM.Infraestructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security> , ISecurityRepository
    {
        public SecurityRepository(SMContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
 
    }
}