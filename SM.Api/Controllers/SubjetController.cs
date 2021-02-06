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
    public class SubjetController : ControllerBase
    {
        private readonly ISubjetService _subjet;
        private readonly IMapper _mapper;
        public SubjetController(ISubjetService subjet, IMapper mapper)
        {
            _subjet = subjet;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetSubjets([FromQuery] SubjetQueryFilters filters)
        {
            var subjet =  _subjet.GetSubjets(filters);
            var subjetDto = _mapper.Map<IEnumerable<SubjetDto>>(subjet);
            var response = new ApiResponse<IEnumerable<SubjetDto>>(subjetDto);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjet(int id)
        {
            var subjet = await _subjet.GetSubjet(id);
            var subjetDto = _mapper.Map<SubjetDto>(subjet);
            var response = new ApiResponse<SubjetDto>(subjetDto);
            return Ok(response);
        }
       [HttpPost]
       public async Task<IActionResult> NewSubjet(SubjetDto subjet)
        {
            var s = _mapper.Map<Subjet>(subjet);
            await _subjet.NewSubjet(s);
            subjet = _mapper.Map<SubjetDto>(s);
            var response = new ApiResponse<SubjetDto>(subjet);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, SubjetDto subjetDto)
        {
            var e = _mapper.Map<Subjet>(subjetDto);
            e.Id = id;
            var result = await _subjet.Update(e);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _subjet.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
