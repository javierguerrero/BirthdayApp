using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetAsync(int id);
        Task CreateAsync(Contact entity);
        Task DeleteAsync(int id);
    }
}
