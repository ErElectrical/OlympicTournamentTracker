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
        public static void SendEmail(string fromaddress,string to,string subject,string body)
        {

        }
        public static void SendEmail(List<string> to, List<string> bcc,string subject,string body)
        {
            MailAddress fromMailAddress = new MailAddress(ConnectionConfig.AppKeyLookup("senderEmail"), ConnectionConfig.AppKeyLookup("senderName"));
            MailMessage mail = new MailMessage();
            foreach(string email in to)
            {
                mail.To.Add(email);
            }
            foreach(string email in bcc)
            {
                mail.To.Add(email);
            }
            mail.Subject = subject;
            mail.From = fromMailAddress;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
        
            client.Send(mail);
        }
    }
}
