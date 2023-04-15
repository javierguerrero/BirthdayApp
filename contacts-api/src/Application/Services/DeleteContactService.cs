using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class DeleteContactService : IDeleteContactService
    {
        private readonly IContactRepository _repository;

        public DeleteContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteContact(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}