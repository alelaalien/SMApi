using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.Core.Services
{
    public class TypeOfService : ITypeOfService
    {
        private readonly IUnitOfWork _typeR;

        public TypeOfService(IUnitOfWork typeR)
        {
            _typeR = typeR;
        }
        public async Task<bool> Delete(int id)
        {
            await _typeR.TypeRepository.Delete(id);
            await _typeR.SaveChangesAsync();
            return true;          
        }

        public async Task<bool> DeleteAll(TypeQueryFilters filters)
        {
            var types = _typeR.TypeRepository.GetAll();
            if(filters.IdUser != null)
            {
                types = types.Where(x=>x.IdUser==filters.IdUser);

                await _typeR.TypeRepository.DeleteAll(types);

            }
            await _typeR.SaveChangesAsync();
            return true;
        }

        public async Task<TypeOf> GetType(int id)
        {
           return await _typeR.TypeRepository.GetById(id);

        }

        public IEnumerable<TypeOf> GetTypes(TypeQueryFilters filters)
        {
            var types = _typeR.TypeRepository.GetAll();

            if (filters.IdUser != null) { types = types.Where(x => x.IdUser == filters.IdUser); }
            if (filters.Id != null) { types = types.Where(x => x.Id == filters.Id); }
            if (filters.Description != null) { types = types.Where(x => x.Description == filters.Description); }

            return types; 
        }

        public async Task NewType( TypeOf _type)
        {
            await _typeR.TypeRepository.Add(_type);
            await _typeR.SaveChangesAsync();

           
        }

        public async Task<bool> Update( TypeOf _type)
        {
              _typeR.TypeRepository.Update(_type);
            await _typeR.SaveChangesAsync();

            return true;
        }
    }
}
