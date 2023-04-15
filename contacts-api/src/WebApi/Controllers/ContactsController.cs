using Application.DTOs;
using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IMapperService _mapperService;
        private readonly IGetAllContactService _getAllContactService;
        private readonly ICreateContactService _createContactService;
        private readonly IGetContactService _getContactService;

        public ContactsController(
            ILogger<ContactsController> logger,
            IGetAllContactService getAllContactService,
            IGetContactService getContactService,
            ICreateContactService createContactService,
            IMapperService mapperService)
        {
            _logger = logger;
            _mapperService = mapperService;
            _getAllContactService = getAllContactService;
            _getContactService = getContactService;
            _createContactService = createContactService;
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactDto dto)
        {
            var entity = _mapperService.ConvertToEntity(dto);
            var output = _mapperService.ConvertToDto(await _createContactService.CreateContact(entity));

            return Ok(output);
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
            var output = _mapperService.ConvertToDto(entity);

            return Ok(output);
        }
    }
}