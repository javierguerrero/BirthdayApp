using Application.Services;
using Domain.Interfaces.Services.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Contacts
{
    [ApiController]
    [Route("[controller]")]
    public class GetContactController : ControllerBase
    {
        private readonly ILogger<GetContactController> _logger;
        private readonly IGetContactService _getContactService;
        private readonly IMapperService _mapperService;

        public GetContactController(
            ILogger<GetContactController> logger,
            IGetContactService getContactService,
            IMapperService mapperService)
        {
            _logger = logger;
            _getContactService = getContactService;
            _mapperService = mapperService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetContact(int id)
        {
            var entity = await _getContactService.GetContactAsync(id);
            var dto = _mapperService.ConvertToDto(entity);
            return Ok(dto);
        }
    }
}