using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class CreateContactService : ICreateContactService
    {
        private readonly IContactRepository _repository;

        public CreateContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            return await _repository.CreateAsync(contact);
        }
    }
}