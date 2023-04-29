using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Notification
{
    public interface INotifier
    {
        public void SendSms(string toPhoneNumber, string message);
    }
}
