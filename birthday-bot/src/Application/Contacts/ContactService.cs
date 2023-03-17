using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Notification;

namespace Application.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly INotifier _notifier;

        public ContactService(IContactRepository contactRepository, INotifier notifier)
        {
            _contactRepository = contactRepository;
            _notifier = notifier;
        }

        public async Task<ICollection<Contact>> GetAllAsync()
        {
            ICollection<Contact> contacts = new List<Contact>();
            try
            {
                contacts = await _contactRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // logging
                throw;
            }

            return contacts;
        }

        public async Task<ICollection<Contact>> GetTodayBirthdaysAsync()
        {
            ICollection<Contact> todayBirthdays = new List<Contact>();

            try
            {
                var contacts = await _contactRepository.GetAllAsync();
                DateTime today = DateTime.Today;
                foreach (var contact in contacts)
                {
                    if (contact.Birthday.Day == today.Day && contact.Birthday.Month == today.Month)
                    {
                        todayBirthdays.Add(contact);
                    }
                }
            }
            catch (Exception ex)
            {
                // logging
                throw;
            }

            return todayBirthdays;
        }

        public async Task<bool> SendMessageToContactAsync(Contact contact)
        {
            var result = false;
            try
            {
                var message = $"¡Feliz cumple, {contact.Name}!. Te escribe Javier Guerrero para desearte un lindo día en compañia de familiares y amigos.";
                _notifier.SendSms(contact.PhoneNumber, message);
            }
            catch (Exception ex)
            {
                //Logging
                throw;
            }

            return result;
        }
    }
}