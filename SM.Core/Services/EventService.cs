using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.Core.Services
{
    public class EventService:IEventService
    {
 
        private readonly IUnitOfWork _eveR;

        public EventService(IUnitOfWork _unit)
        {
            _eveR = _unit;
        }

        public async Task<bool> Delete(int id)
        {
            await _eveR.EventRepository.Delete(id);
            await _eveR.SaveChangesAsync();
            return true;
        }

        public async Task<Event> GetEvent(int id)
        {
            return  await _eveR.EventRepository.GetById(id);
        }

        public IEnumerable<Event> GetEvents(EventQueryFilters filters)
        {
            var events = _eveR.EventRepository.GetAll();

            if(filters.Id!= null) { events = events.Where(x => x.Id == filters.Id); }
            if (filters.IdSubjet != null) { events = events.Where(x => x.IdSubjet == filters.IdSubjet); }
            if (filters.Date != null) { events = events.Where(x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString()); }
            if (filters.IdUser != null) { events = events.Where(x => x.IdUser == filters.IdUser); }
            if (filters.Title != null) { events = events.Where(x => x.Title.ToLower() == filters.Title.ToLower()); }
            if (filters.TypeId != null) { events = events.Where(x => x.TypeId == filters.TypeId); }
            if (filters.Active != null) { events = events.Where(x => x.Active == filters.Active); }
            if (filters.Priority != null) { events = events.Where(x => x.Priority == filters.Priority); }
            if (filters.Notes != null) { events = events.Where(x => x.Notes.ToLower().Contains(filters.Notes.ToLower())); }

            return events;
        }

        public async Task NewEvent(Event _event)
        {

            var subjet = await _eveR.SubjetRepository.GetById(_event.IdSubjet);
            var user = await _eveR.UserRepository.GetById(_event.IdUser);
            if (subjet == null)
            {

                throw new Exception("La materia no existe");
            }
            if (user == null)
            {

                throw new Exception("El usuario no existe");
            }
            var date = _event.Date;
            if (date < DateTime.Now)
            {

                throw new Exception("Corregir fecha");
            }

            await _eveR.EventRepository.Add(_event);
            await _eveR.SaveChangesAsync();

        }

        public async Task<bool> Update(Event _event)
        {
            var date = _event.Date;
            if (date < DateTime.Now)
            {

                throw new Exception("Corregir fecha");
            }
            _eveR.EventRepository.Update(_event);
          await  _eveR.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAll(EventQueryFilters filters)
        {
            var events = _eveR.EventRepository.GetAll();

            if (filters.IdUser != null && filters.IdSubjet !=null)
            {


                events = events.Where(x => x.IdUser == filters.IdUser);
                events = events.Where(x => x.IdSubjet == filters.IdSubjet);

                await _eveR.EventRepository.DeleteAll(events);

            }
            if (filters.IdUser != null)
            {

                events = events.Where(x => x.IdUser == filters.IdUser);
             
                await _eveR.EventRepository.DeleteAll(events);

            }
            if (filters.TypeId != null)
            {

                events = events.Where(x => x.TypeId == filters.TypeId);

                await _eveR.EventRepository.DeleteAll(events);

            }
            await _eveR.SaveChangesAsync();
            return true;

        }
    }
}
