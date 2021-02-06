using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SM.Api.Response;
using SM.Core.DTOs;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SM.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacher;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacher, IMapper mapper)
        {
            _teacher = teacher;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetTeachers([FromQuery] TeacherQueryFilters filters)
        {

            var teacher =   _teacher.GetTeachers(filters);
            var teacherDto = _mapper.Map<IEnumerable<TeacherDto>>(teacher);
            var response = new ApiResponse<IEnumerable<TeacherDto>>(teacherDto);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher = await _teacher.GetTeacher(id);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            var response = new ApiResponse<TeacherDto>(teacherDto);
            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> NewTeacher(TeacherDto teacherDto)
        {
            var t = _mapper.Map<Teacher>(teacherDto);
            await _teacher.NewTeacher(t);
            teacherDto = _mapper.Map<TeacherDto>(t);
            var response = new ApiResponse<TeacherDto>(teacherDto);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, TeacherDto teacherDto)
        {
            var e = _mapper.Map<Teacher>(teacherDto);
            e.Id = id;
            var result= await _teacher.Update(e);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _teacher.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
