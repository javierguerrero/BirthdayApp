using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public readonly ApplicationContext _context;

        public ContactRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Contact> GetAsync(int id)
        {
            return await _context.Contacts.SingleAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.SingleAsync(c => c.Id == id);

            if (contact is not null) { 
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Contact> CreateAsync(Contact entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}