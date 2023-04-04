using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Contacts
{
    public interface IDeleteContactService
    {
        void DeleteContact(int contactId);
    }
}
