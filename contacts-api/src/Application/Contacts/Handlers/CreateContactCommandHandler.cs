using Application.Contacts.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Contacts.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(CreateContactCommand command, CancellationToken cancellationToken)
        {
            Contact contact = new Contact
            {
                Name = command.Name,
                LastName = command.LastName,
                Birthday = command.Birthday,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
            };
            await _contactRepository.AddAsync(contact);
        }
    }
}