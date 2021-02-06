using SM.Core.Entities;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(EventQueryFilters filters);
        Task<Event> GetEvent(int id);
        Task NewEvent(Event _event);
        Task<bool> Update(Event _event);
        Task<bool> Delete(int id);
    }
}
