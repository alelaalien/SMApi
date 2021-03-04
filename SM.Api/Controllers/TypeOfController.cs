using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfController : ControllerBase
    {
        private readonly ITypeOfService _typeS;
        private readonly IMapper _mapper;

        public TypeOfController(ITypeOfService _type, IMapper _mappers)
        {
            _typeS = _type;
            _mapper = _mappers;
        }

            [HttpGet]
            [ProducesResponseType((int)HttpStatusCode.OK)]
            [ProducesResponseType((int)HttpStatusCode.BadRequest)]
            public IActionResult GetTypeOfs([FromQuery] TypeQueryFilters filters)
            {

                var typeOf = _typeS.GetTypes(filters);
                var typeOfDto = _mapper.Map<IEnumerable<TypeOfDto>>(typeOf); 
                return Ok(typeOfDto);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GettypeOf(int id)
            {
                var typeOf = await _typeS.GetType(id);
                var typeOfDto = _mapper.Map<TypeOfDto>(typeOf);
                var response = new ApiResponse<TypeOfDto>(typeOfDto);
                return Ok(response);

            }
            [HttpPost]
            public async Task<IActionResult> NewtypeOf(TypeOfDto typeOfDto)
            {
                var t = _mapper.Map<TypeOf>(typeOfDto);
                await _typeS.NewType(t);
                typeOfDto = _mapper.Map<TypeOfDto>(t);
                var response = new ApiResponse<TypeOfDto>(typeOfDto);
                return Ok(response);
            }
            [HttpPut]
            public async Task<IActionResult> Update(int id, TypeOfDto typeOfDto)
            {
                var e = _mapper.Map<TypeOf>(typeOfDto);
                e.Id = id;
                var result = await _typeS.Update(e);
                var response = new ApiResponse<bool>(result);
                return Ok(response);

            }
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
             {

                var result = await _typeS.Delete(id);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
            [Route("deleteall")]
            [HttpDelete]
            public async Task<IActionResult> DeleteAll([FromQuery] TypeQueryFilters filters)
            {

                var result = await _typeS.DeleteAll(filters);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }

        }
}
