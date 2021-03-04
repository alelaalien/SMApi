using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SM.Core.Services
{
    public class TeacherService:ITeacherService
    {
        private readonly IUnitOfWork _teachR;

        public TeacherService(IUnitOfWork teacherRepository)
        {
            _teachR = teacherRepository;
        }

        public async Task<bool> Delete(int id)
        {
           await _teachR.TeacherRepository. Delete(id);
            await _teachR.SaveChangesAsync();
            return true;

        }

        public async Task<Teacher> GetTeacher(int id)
        {
            return await _teachR.TeacherRepository.GetById(id);
        }

        public  IEnumerable<Teacher>  GetTeachers(TeacherQueryFilters filters)
        {
            var teachers= _teachR.TeacherRepository.GetAll();
            if (filters.IdUser != null) { teachers = teachers.Where(x => x.IdUser == filters.IdUser); }
            if (filters.Id != null) { teachers = teachers.Where(x => x.Id == filters.Id); }
            if (filters.Name != null) { teachers = teachers.Where(x => x.Name.ToLower() == filters.Name.ToLower()); }
            if (filters.Surname != null) { teachers = teachers.Where(x => x.Surname.ToLower() == filters.Surname.ToLower()); }
            if (filters.Nick != null) { teachers = teachers.Where(x => x.Nick.ToLower() == filters.Nick.ToLower()); }
            if (filters.Celphone != null) { teachers = teachers.Where(x => x.Celphone == filters.Celphone); }
            if (filters.Email != null) { teachers = teachers.Where(x => x.Email.ToLower() == filters.Email.ToLower()); }

            return teachers;
        }

        public async Task NewTeacher(Teacher _teacher)
        {
            await _teachR.TeacherRepository.Add(_teacher);
            await _teachR.SaveChangesAsync();
        }

        public async Task<bool> Update(Teacher _teacher)
        {
             _teachR.TeacherRepository.Update(_teacher);
            await _teachR.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAll(TeacherQueryFilters filters)
        {
            var teachers = _teachR.TeacherRepository.GetAll();

            if (filters.IdUser != null)
            {

                teachers = teachers.Where(x => x.IdUser == filters.IdUser);

                await _teachR.TeacherRepository.DeleteAll(teachers);

            }
            await _teachR.SaveChangesAsync();
            return true;

        }
    }
}
