using Application.DTOs;
using Application.Services;
using Application.Services.Contacts;
using Domain.Interfaces.Services.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IGetAllContactService _getAllContactService;
        private readonly IGetContactService _getContactService;
        private readonly IMapperService _mapperService;

        public ContactsController(
            ILogger<ContactsController> logger, 
            IGetAllContactService getAllContactService,
            IGetContactService getContactService,
            IMapperService mapperService)
        {
            _logger = logger;
            _getAllContactService = getAllContactService;
            _getContactService = getContactService;
            _mapperService = mapperService;
        }

        //GET /contacts
        [HttpGet]
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

        //GET /contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var entity = await _getContactService.GetContactAsync(id);
            var dto = _mapperService.ConvertToDto(entity);
            return Ok(dto);
        }
    }
}