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
        Task<Contact> GetAsync(int id);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> CreateAsync(Contact entity);
        Task UpdateAsync(Contact entity);
        Task DeleteAsync(int id);
    }
}
