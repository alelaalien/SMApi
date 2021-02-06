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
            if (filters.IdTeacher != null) { events = events.Where(x => x.IdTeacher == filters.IdTeacher); }
            if (filters.Title != null) { events = events.Where(x => x.Title.ToLower() == filters.Title.ToLower()); }
            if (filters.TypeOf != null) { events = events.Where(x => x.TypeOf == filters.TypeOf); }
            if (filters.Active != null) { events = events.Where(x => x.Active == filters.Active); }
            if (filters.Priority != null) { events = events.Where(x => x.Priority == filters.Priority); }
            if (filters.Notes != null) { events = events.Where(x => x.Notes.ToLower().Contains(filters.Notes.ToLower())); }

            return events;
        }

        public async Task NewEvent(Event _event)
        {

            var subjet = await _eveR.SubjetRepository.GetById(_event.IdSubjet);
            var teacher = await _eveR.TeacherRepository.GetById(_event.IdTeacher);
            if (subjet == null)
            {

                throw new Exception("La materia no existe");
            }
            if (teacher == null)
            {

                throw new Exception("El docente no existe");
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
    }
}
