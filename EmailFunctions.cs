using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace CSharpExamples
{
    class EmailFunctions
    {
        //function sends emails
        public static void SendMail(string RecipientMail, string RecipientName, string MailSubject, string MailBody)
        {
            int Port = 587;
            string Host = "smtp.gmail.com";
            string Username = "test@gmail.com";
            string Password = "gmailpassword";
            string SenderMail = Username;
            string SenderName = "My App";

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(Username, Password);
            client.Port = Port;
            client.Host = Host;
            client.EnableSsl = true;
            try
            {
                using (MailMessage emailMessage = new MailMessage())
                {
                    emailMessage.From = new MailAddress(SenderMail, SenderName);
                    emailMessage.To.Add(new MailAddress(RecipientMail, RecipientName));
                    emailMessage.Subject = MailSubject;
                    emailMessage.SubjectEncoding = Encoding.UTF8;
                    emailMessage.Body = MailBody;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.BodyEncoding = Encoding.UTF8;
                    emailMessage.Priority = MailPriority.Normal;
                    using (SmtpClient MailClient = new SmtpClient(Host, Port))
                    {
                        MailClient.EnableSsl = true;
                        MailClient.Credentials = new System.Net.NetworkCredential(Username, Password);
                        MailClient.Send(emailMessage);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Encountered an error: " + e.ToString());
            }

        }
        //function sends emails with attachment
        public static void SendMailAttachemnt(string RecipientMail, string RecipientName, string MailSubject, string MailBody, string file)
        {
            int Port = 587;
            string Host = "smtp.gmail.com";
            string Username = "test@gmail.com";
            string Password = "gmailpassword";
            string SenderMail = Username;
            string SenderName = "My App";

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(Username, Password);
            client.Port = Port;
            client.Host = Host;
            client.EnableSsl = true;
            try
            {
                using (MailMessage emailMessage = new MailMessage())
                {
                    emailMessage.From = new MailAddress(SenderMail, SenderName);
                    emailMessage.To.Add(new MailAddress(RecipientMail, RecipientName));
                    emailMessage.Subject = MailSubject;
                    emailMessage.SubjectEncoding = Encoding.UTF8;
                    emailMessage.Body = MailBody;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.BodyEncoding = Encoding.UTF8;
                    emailMessage.Priority = MailPriority.Normal;

                    // Create  the file attachment for this e-mail message.
                    Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                    // Add the file attachment to this e-mail message.
                    emailMessage.Attachments.Add(data);
                    emailMessage.Attachments.Add(data);


                    using (SmtpClient MailClient = new SmtpClient(Host, Port))
                    {
                        MailClient.EnableSsl = true;
                        MailClient.Credentials = new System.Net.NetworkCredential(Username, Password);
                        MailClient.Send(emailMessage);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Encountered an error: " + e.ToString());
            }
        }
        
    }
}
