using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts
{
    public interface IContactService
    {
        Task<ICollection<Contact>> GetAllAsync();
        Task<bool> SendMessageToContactAsync(Contact contact);
        Task<ICollection<Contact>> GetTodayBirthdaysAsync();
    }
}
