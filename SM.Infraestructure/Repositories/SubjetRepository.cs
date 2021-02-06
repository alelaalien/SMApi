using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Infraestructure.Repositories
{
    public class SubjetRepository//: ISubjetRepository
    {
//        private SMContext _context;
//        public SubjetRepository(SMContext sm)
//        {
//            _context = sm;

//        }
//       public async Task<IEnumerable<Subjet>> GetSubjets()
//        {
//            var subjets = await _context.Subjet.ToListAsync()
//;            return subjets;
//        }
//        public async Task<Subjet> GetSubjet(int id)
//        {
//            var subjet = await _context.Subjet.FirstOrDefaultAsync(x => x.Id == id);
//            return subjet;
//        }
//        public async Task  NewSubjet(Subjet subjet)
//        {
//            _context.Subjet.Add(subjet);
//            await _context.SaveChangesAsync();
            
//        }
//        public async Task<bool> Update(Subjet _subjet)
//        {
//            var currSubjet = await GetSubjet(_subjet.Id);
//            currSubjet.Class = _subjet.Class;
//            currSubjet.QueryClasses = _subjet.QueryClasses;
//            currSubjet.Active = _subjet.Active;
//            currSubjet.Name = _subjet.Name;
//            currSubjet.Notes = _subjet.Notes;

//            int rows = await _context.SaveChangesAsync();
//            return rows > 0;
//        }
//        public async Task<bool> Delete(int id)
//        {
//            var currSubjet = await GetSubjet(id);
//            _context.Subjet.Remove(currSubjet);
//            int rows = await _context.SaveChangesAsync();
//            return rows > 0;

//        }


    }
}
