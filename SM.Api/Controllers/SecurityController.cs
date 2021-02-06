using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SM.Api.Response;
using SM.Core.DTOs;
using SM.Core.Entities;
using SM.Core.Enumerations;
using SM.Core.Interfaces;
using SM.Infraestructure.Interfaces;
using System.Threading.Tasks;

namespace SM.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _hasher;


        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordHasher hasher)
        {
            _securityService = securityService;
            _mapper = mapper;
            _hasher = hasher;
        }
        [HttpPost]
        public async Task<IActionResult> Post(SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);
            security.Pass=_hasher.Hash(security.Pass);      
            await _securityService.Register(security);

            securityDto = _mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(securityDto);
            return Ok(response);
        }
    }
}
