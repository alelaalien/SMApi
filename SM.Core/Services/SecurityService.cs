using SM.Core.Entities;
using SM.Core.Interfaces;
using System.Threading.Tasks;

namespace SM.Core.Services
{
    public class SecurityService:ISecurityService
    {
        private readonly IUnitOfWork _unit;
        public SecurityService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _unit.SecurityRepository.GetLoginByCredentials(login);
        }
        public async Task  Register(Security security)
        {
            await _unit.SecurityRepository.Add(security);
            await _unit.SaveChangesAsync();
        }
    }
}
