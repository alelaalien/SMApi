using SM.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Event> EventRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Teacher> TeacherRepository { get; }
        IRepository<TypeOf> TypeRepository { get; }
        IRepository<Subjet> SubjetRepository { get; }
        IRepository<Dictates> DictatesRepository { get; }
        ISecurityRepository SecurityRepository { get; } 
        IUserRepository UserRepositoryLogin { get; }
 
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
