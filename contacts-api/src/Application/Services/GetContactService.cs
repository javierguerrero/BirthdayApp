using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
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