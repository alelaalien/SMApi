using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
    public class DictatesService : IDictatesService 
{

    private readonly IUnitOfWork unit;
         
        public DictatesService(IUnitOfWork i )
        {
        unit = i;

        }

        public async Task<bool> Delete(DictatesQueryFilters filters)
        {
        var dic = unit.DictatesRepository.GetAll();

            if (filters.TeacherId!=null)
            {
                dic = dic.Where(x => x.TeacherId == filters.TeacherId);

                await unit.DictatesRepository.DeleteAll(dic);

            }
            if (filters.SubjetId != null)
            {

                dic = dic.Where(x => x.SubjetId == filters.SubjetId);

                await unit.DictatesRepository.DeleteAll(dic);

            }
 
            await unit.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Dictates> GetDictates(DictatesQueryFilters filters)
        {
        var dictates = unit.DictatesRepository.GetAll();
        if (filters.SubjetId != null) { dictates = dictates.Where(x => x.SubjetId == filters.SubjetId); }
        if (filters.TeacherId != null) { dictates = dictates.Where(x => x.TeacherId == filters.TeacherId); }

        return dictates;
    }

    public async Task NewDictates(Dictates _dictates)
        {
        await unit.DictatesRepository.Add(_dictates);
        await unit.SaveChangesAsync();
    }
     
}
