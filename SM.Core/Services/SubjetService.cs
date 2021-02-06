using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.Core.Services
{
    public class SubjetService:ISubjetService
    {
        private readonly IUnitOfWork _subR;


        public SubjetService(IUnitOfWork subjetRepository)
        {
            _subR = subjetRepository;

        }

        public async Task<bool> Delete(int id)
        {
            await _subR.SubjetRepository.Delete(id);
            await _subR.SaveChangesAsync();
            return true;
        }

        public async Task<Subjet> GetSubjet(int id)
        {
            return await _subR.SubjetRepository.GetById(id);
        }

        public IEnumerable<Subjet> GetSubjets(SubjetQueryFilters filters)
        {
             var subjets=  _subR.SubjetRepository.GetAll();
            if (filters.Id != null) { subjets = subjets.Where(x => x.Id == filters.Id); }
            if (filters.Name != null) { subjets = subjets.Where(x => x.Name.ToLower() == filters.Name.ToLower()); }
            if (filters.IdUser != null) { subjets = subjets.Where(x => x.IdUser == filters.IdUser); }
            if (filters.Active != null) { subjets = subjets.Where(x => x.Active == filters.Active); }


            return subjets;
        }

        public async Task NewSubjet(Subjet subjet)
        {
            var user = await _subR.UserRepository.GetById(subjet.IdUser);
            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }
            await _subR.SubjetRepository.Add(subjet);
            await _subR.SaveChangesAsync();
        }

        public async Task<bool> Update(Subjet subjet)
        {
              _subR.SubjetRepository.Update(subjet);
            await _subR.SaveChangesAsync();
            return true;
        }
    }
}
