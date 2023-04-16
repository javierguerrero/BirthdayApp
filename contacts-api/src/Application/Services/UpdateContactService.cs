using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class UpdateContactService : IUpdateContactService
    {
        private readonly IContactRepository _repository;

        public UpdateContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateContact(Contact contact)
        {
            await _repository.UpdateAsync(contact);
        }
    }
}