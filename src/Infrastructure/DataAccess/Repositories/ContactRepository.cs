using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public async Task<ICollection<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
