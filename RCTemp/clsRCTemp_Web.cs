using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace RCTemp
{
    public class clsRCTemp_Web
    {
        public void SendMailMessage(string theNotification)
        {

            try
            {



                string to = My.MySettingsProperty.Settings.EmailTo;
                string cc = string.Empty;

                var mMailMessage = new MailMessage();

                mMailMessage.From = new MailAddress(My.MySettingsProperty.Settings.EmailFrom);   // Set the sender address of the mail message
                mMailMessage.To.Add(to);  // Set the recepient address of the mail message

                // Check If the bcc value Is null Or an empty string
                if (!string.IsNullOrEmpty(My.MySettingsProperty.Settings.EmailBcc) && !string.IsNullOrEmpty(My.MySettingsProperty.Settings.EmailBcc))
                {
                    // Set the Bcc address of the mail message
                    mMailMessage.Bcc.Add(new MailAddress(My.MySettingsProperty.Settings.EmailBcc));
                }

                if (!string.IsNullOrEmpty(My.MySettingsProperty.Settings.EmailCc) && !string.IsNullOrEmpty(My.MySettingsProperty.Settings.EmailCc))  // Check if the cc value is null or an empty value
                {
                    // Set the CC address of the mail message
                    mMailMessage.CC.Add(cc);
                }

                mMailMessage.Subject = My.MySettingsProperty.Settings.EmailSubject;  // Set the subject of the mail message"
                mMailMessage.Body = theNotification;  // Set the body of the mail message
                mMailMessage.IsBodyHtml = true;  // Set the format of the mail message body as HTML
                mMailMessage.Priority = MailPriority.Normal; // Set the priority of the mail message to normal

                var mSmtpClient = new SmtpClient(My.MySettingsProperty.Settings.SmtpServerID); // Instantiate a new instance of SmtpClient

                mSmtpClient.Send(mMailMessage); // Send the mail message

                mMailMessage.Dispose();
            }

            catch (Exception)
            {

            }
        }
    }
}