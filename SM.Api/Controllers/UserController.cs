using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SM.Api.Response;
using SM.Core.DTOs;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using SM.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
namespace SM.Api.Controllers
{
    //// 
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _hasher;
        public UserController(IUserService user, IMapper mapper, IPasswordHasher hasher)
        {
            _user = user;
            _mapper = mapper;
            _hasher = hasher;
        }
        /// <summary>
        /// Retrieve all Users
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetUsers([FromQuery] UserQueryFilters filters)
        {
            var user =   _user.GetUsers(filters);
            var userDto = _mapper.Map<IEnumerable<UserDto>>(user);
            var response = new ApiResponse<IEnumerable<UserDto>>(userDto);
            return Ok(userDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _user.GetUser(id);
            var userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(userDto); 
        }
        [HttpPost]
        public async Task<IActionResult> NewUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Password = _hasher.Hash(user.Password);
            await _user.NewUser(user);
           
            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);

        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            var e = _mapper.Map<User>(userDto);
            e.Id = id;
            var result= await _user.Update(e);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _user.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }




    }
}
