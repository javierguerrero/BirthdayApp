using MediatR;

namespace Application.Contacts.Commands
{
    public class CreateContactCommand : IRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}