using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Infraestructure.Repositories
{
    //public class TeacherRepository:ITeacherRepository
    //{
    //    private SMContext _context;
    //    public TeacherRepository(SMContext sm)
    //    {
    //        _context = sm;
    //    }
    //    public async Task<IEnumerable<Teacher>> GetTeachers()
    //    {
    //        var Teachers = await _context.Teacher.ToListAsync()
    //    ; return Teachers;
    //    }
    //    public async Task<Teacher> GetTeacher(int id)
    //    {
    //        var Teacher = await _context.Teacher.FirstOrDefaultAsync(x => x.Id == id);
    //        return Teacher;
    //    }
    //    public async Task NewTeacher(Teacher teacher)
    //    {
    //        _context.Teacher.Add(teacher);
    //        await _context.SaveChangesAsync();

    //    }
    //    public async Task<bool> Update(Teacher _teacher)
    //    {
    //        var currTeacher = await GetTeacher(_teacher.Id); 
    //        currTeacher.Name = _teacher.Name;
    //        currTeacher.Nick = _teacher.Nick;
    //        currTeacher.Surname = _teacher.Surname;
    //        currTeacher.Celephone = _teacher.Celephone;
    //        currTeacher.Email = _teacher.Email;
    //        currTeacher.Subjets = _teacher.Subjets;
    //        int rows = await _context.SaveChangesAsync();
    //        return rows > 0;
    //    }
    //    public async Task<bool> Delete(int id)
    //    {
    //        var currTeacher = await GetTeacher(id);
    //        _context.Teacher.Remove(currTeacher);
    //        int rows = await _context.SaveChangesAsync();
    //        return rows > 0;

    //    }
    //}
}
