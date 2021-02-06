using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Infraestructure.Repositories
{
    public class EventRepository: IEventRepository
    {
        private SMContext _context;
        public EventRepository(SMContext sm)
        {
            _context = sm;
        }
        public async Task<IEnumerable<Event>> GetEvents()
        {
            var Events = await _context.Event.ToListAsync()
; return Events;
        }
        public async Task<Event> GetEvent(int id)
        {
            var Event = await _context.Event.FirstOrDefaultAsync(x => x.Id == id);
            return Event;
        }
        public async Task NewEvent(Event _event)
        {
            _context.Event.Add(_event);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> Update(Event _event)
        {
            var currEvent = await GetEvent(_event.Id);
            currEvent.IdSubjet = _event.IdSubjet;
            currEvent.Notes = _event.Notes;
            currEvent.Active = _event.Active;
            currEvent.Date = _event.Date;
            currEvent.Priority = _event.Priority;
            currEvent.TypeOf = _event.TypeOf;
            currEvent.IdTeacher = _event.IdTeacher;
            currEvent.Title = _event.Title;
            int rows = await _context.SaveChangesAsync();
            return rows>0;
        }

        public async Task<bool> Delete(int id)
        {
            var currEvent = await GetEvent(id);
            _context.Event.Remove(currEvent);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
    }
}
