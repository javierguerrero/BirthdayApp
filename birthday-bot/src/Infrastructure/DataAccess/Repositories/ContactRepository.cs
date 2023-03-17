using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationContext _context;

        public ContactRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Contact>> GetAllAsync()
        {
            var contacts = new List<Contact>();
            contacts = await _context.Contacts.ToListAsync();
            return contacts;
        }
    }
}