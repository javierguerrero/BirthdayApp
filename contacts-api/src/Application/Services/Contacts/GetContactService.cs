using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services.Contacts;

namespace Application.Services.Contacts
{
    public class GetContactService : IGetContactService
    {
        private readonly IContactRepository _repository;

        public GetContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<Contact> GetContactAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
    }
}