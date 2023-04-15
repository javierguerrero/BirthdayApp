using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class GetAllContactService : IGetAllContactService
    {
        private readonly IContactRepository _repository;

        public GetAllContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _repository.GetAllAsync();
        }
    }
}