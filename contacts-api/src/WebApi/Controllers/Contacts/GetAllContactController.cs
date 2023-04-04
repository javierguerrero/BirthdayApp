using Application.DTOs;
using Application.Services;
using Domain.Interfaces.Services.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Contacts
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllContactController : ControllerBase
    {
        private readonly ILogger<GetAllContactController> _logger;
        private readonly IGetAllContactService _getAllContactService;
        private readonly IMapperService _mapperService;

        public GetAllContactController(ILogger<GetAllContactController> logger, IGetAllContactService getAllContactService, IMapperService mapperService)
        {
            _logger = logger;
            _getAllContactService = getAllContactService;
            _mapperService = mapperService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllContacts()
        {
            var entities = await _getAllContactService.GetAllContacts();

            var results = new List<ContactDto>();
            foreach (var entity in entities)
            {
                results.Add(_mapperService.ConvertToDto(entity));
            }
            return Ok(results);
        }
    }
}