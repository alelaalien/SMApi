using SM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeacher(int id);
        Task NewTeacher(Teacher _teacher);
        Task<bool> Update(Teacher _teacher);
        Task<bool> Delete(int id);
    }
}
