using SM.Core.Entities;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface ISubjetService
    {
        IEnumerable<Subjet> GetSubjets(SubjetQueryFilters filters);
        Task<Subjet> GetSubjet(int id);
        Task NewSubjet(Subjet subjet);
        Task<bool> Update(Subjet subjet);
        Task<bool> Delete(int id);
        Task<bool> DeleteAll(SubjetQueryFilters filters);
    }
}
