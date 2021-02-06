using SM.Core.DTOs;
using SM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> GetEvent(int id);
        Task NewEvent(Event _event);
        Task<bool> Update(Event _event);
        Task<bool> Delete(int id);
    }
}
