using Application.Contacts.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.Handlers
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<Contact>>
    {
        readonly IContactRepository _contactRepository;

        public GetAllContactsQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> Handle(GetAllContactsQuery query, CancellationToken cancellationToken)
        {
            return await _contactRepository.GetAllAsync();
        }
    }
}
