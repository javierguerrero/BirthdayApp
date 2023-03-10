using Domain.Entities;
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
        private readonly ApplicationContext _context;

        public ContactService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Contact>> GetAllAsync()
        {
            var contacts = new List<Contact>();
            try
            {
                contacts = await _context.Contacts.ToListAsync();
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
