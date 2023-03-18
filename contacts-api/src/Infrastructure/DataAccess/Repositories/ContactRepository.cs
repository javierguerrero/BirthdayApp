using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public readonly ApplicationContext _context;

        public ContactRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Contact entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}