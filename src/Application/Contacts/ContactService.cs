using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
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

        public async Task<ICollection<Contact>> GetTodayBirthdays()
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
    }
}
