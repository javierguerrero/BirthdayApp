using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Contacts
{
    public interface ICreateContactService
    {
        Contact CreateContact(Contact contact);
    }
}
