using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMailDesign.Model
{
    public class MailObject
    {
        public string To { get; set; }

        public string From { get; set; } = Configuration.Netsis_Mail;

        public MailProviderType ProviderType { get; set; } 

        // New property for Base64 encoded PDF
        public byte[]? Base64Key { get; set; }

        // New property for email subject
        public string Subject { get; set; } = Configuration.MailSubject;
    }

    public enum MailProviderType
    {
        Smtp = 1,
       // GoogleMail = 2
    }
}
