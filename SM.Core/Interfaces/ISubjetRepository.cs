using Microsoft.AspNetCore.Mvc;
using SM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public  interface ISubjetRepository
    {
        Task<IEnumerable<Subjet>> GetSubjets();
        Task<Subjet> GetSubjet(int id);
        Task NewSubjet(Subjet subjet);
        Task<bool> Update(Subjet subjet);
        Task<bool> Delete(int id);
        Task<bool> DeleteAll(int id);

    }
}
