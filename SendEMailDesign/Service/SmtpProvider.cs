using SendEMailDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;

namespace SendEMailDesign.Service
{
    public class SmtpProvider : BaseProvider
    {
        public override async Task Send(MailObject mailObject)
        {
        using var smtpClient = new SmtpClient(ServerHostName, Port);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(mailObject.From),
                Subject = mailObject.Subject,
                Body = "", 
                IsBodyHtml = true
            };

            mailMessage.To.Add(mailObject.To);

            // Eğer bir dosya eklenecekse
            if (mailObject.Base64Key != null)
            {
                var attachment = new Attachment(new MemoryStream(mailObject.Base64Key), $"{Configuration.PdfName}.pdf", MediaTypeNames.Application.Pdf);
                mailMessage.Attachments.Add(attachment);
            }

            await smtpClient.SendMailAsync(mailMessage);
          

        }
    }
}
