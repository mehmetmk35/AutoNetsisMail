using SendEMailDesign.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMailDesign.Service
{
    public class MailManager
    {
        private readonly ConcurrentQueue<MailObject> mailObjects = new ConcurrentQueue<MailObject>();


        public void AddMails(IEnumerable<MailObject> mails)
        {
            foreach (var mail in mails)
            {
                mailObjects.Enqueue(mail);
            }
        }
        public async Task SendAllMails()
        {
            var smtpProvider = new SmtpProvider();

            while (mailObjects.Count > 0)
            {
                mailObjects.TryDequeue(out MailObject mail);
                
                await smtpProvider.Send(mail);
            }

             
        }

         
    }
}
