using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            return CreatedAtAction(nameof(PostContact), contact);
        }


        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return (IEnumerable<Contact>)Ok();
        }
    }
}