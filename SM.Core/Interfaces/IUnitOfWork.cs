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
        IRepository<Subjet> SubjetRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
