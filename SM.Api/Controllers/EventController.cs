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
    public class EventController : ControllerBase
    {
        private readonly IEventService _event;
        private readonly IMapper _mapper;
        public EventController(IEventService eventR, IMapper mapper)
        {
            _event = eventR;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult  GetEvents([FromQuery] EventQueryFilters filters)
        {
            var events =  _event.GetEvents(filters);
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(events);
            var response = new ApiResponse<IEnumerable<EventDto>>(eventsDto);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var e = await _event.GetEvent(id);
            var eventsDto = _mapper.Map<EventDto>(e);
            var response = new ApiResponse<EventDto>(eventsDto);
            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> NewEvent(EventDto eD)
        {
            var _e = _mapper.Map<Event>(eD);
            await _event.NewEvent(_e);
            eD = _mapper.Map<EventDto>(_e);
            var response = new ApiResponse<EventDto>(eD);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, EventDto eventDto)
        {

            var e= _mapper.Map<Event>(eventDto);
            e.Id = id;
            var result= await _event.Update(e);
            var response = new ApiResponse<bool>(result);
            return Ok(response);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _event.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
