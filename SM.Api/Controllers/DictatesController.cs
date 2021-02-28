using Microsoft.AspNetCore.Mvc;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Core.QueryFilters;
using System.Net;
using System.Threading.Tasks;

namespace SM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictatesController : ControllerBase
    {
        private readonly IDictatesService _ds;
        public DictatesController(IDictatesService ds)
        {
            _ds = ds;
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetDictates([FromQuery] DictatesQueryFilters filters)
        {
            var dic = _ds.GetDictates(filters);
            return Ok(dic);
        }
        [HttpPost]
        public async Task<IActionResult> NewDictates(Dictates d)
        {            
            await _ds.NewDictates(d);  
            return Ok(d);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DictatesQueryFilters filters)
        {

            var result = await _ds.Delete(filters);
            return Ok(result);
        }


    }
}
