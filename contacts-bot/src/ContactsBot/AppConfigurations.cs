using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBot
{
    public class EmailConfiguration
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
    }

    public class SmtpConfiguration
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AppConfigurations
    {
        public EmailConfiguration Email { get; set; }
        public SmtpConfiguration Smtp { get; set; }
    }
}
