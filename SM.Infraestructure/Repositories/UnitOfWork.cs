using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Data;
using System.Threading.Tasks;

namespace SM.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SMContext _context;
        private readonly IRepository<Event> _eveR;
        private readonly IRepository<Teacher> _teachR;
        private readonly IRepository<Subjet> _subR;
        private readonly IRepository<Dictates> _dicR;
        private readonly IRepository<User> _useR;
        private readonly IUserRepository _useRL;
        private readonly ISecurityRepository _secR;
        private readonly IRepository<TypeOf> _typeR; 


        public UnitOfWork(SMContext sMContext)
        {
            _context = sMContext;
        }

        public IRepository<Event> EventRepository => _eveR ?? new BaseRepository<Event>(_context);

        public IRepository<User> UserRepository => _useR ?? new BaseRepository<User>(_context);

        public IRepository<Teacher> TeacherRepository => _teachR ?? new BaseRepository<Teacher>(_context);

        public IRepository<Subjet> SubjetRepository => _subR ?? new BaseRepository<Subjet>(_context);

        public IRepository<TypeOf> TypeRepository => _typeR ?? new BaseRepository<TypeOf>(_context);

        public ISecurityRepository  SecurityRepository => _secR ?? new SecurityRepository(_context);

        public IUserRepository UserRepositoryLogin => _useRL ?? new UserRepository (_context);
        public IRepository<Dictates> DictatesRepository => _dicR ?? new BaseRepository<Dictates>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
