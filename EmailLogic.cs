using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace TournamentTracker
{
    public static  class EmailLogic
    {
        public static void SendEmail(String fromAddress, string to,string subject,string body)
        {
            MailAddress fromMailAddress = new MailAddress(fromAddress, ConnectionConfig.AppKeyLookup("senderName"));
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.Subject = subject;
            mail.From = fromMailAddress;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
        
            client.Send(mail);
        }
    }
}
