using SM.Core.Entities;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetTeachers(TeacherQueryFilters filters);
        Task<Teacher> GetTeacher(int id);
        Task NewTeacher(Teacher _teacher);
        Task<bool> Update(Teacher _teacher);
        Task<bool> Delete(int id);
        Task<bool> DeleteAll(TeacherQueryFilters filters);
    }
}
