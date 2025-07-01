using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace RCTemp
{
    public class clsRCTemp_Web
    {
        public void SendMailMessage(string theNotification)
        {
            try
            {
                // Replace 'My.MySettingsProperty.Settings' with ConfigurationManager.AppSettings
                string to = ConfigurationManager.AppSettings["EmailTo"];
                string cc = string.Empty;

                var mMailMessage = new MailMessage();

                mMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"]); // Set the sender address of the mail message
                mMailMessage.To.Add(to); // Set the recipient address of the mail message

                // Check if the Bcc value is null or an empty string
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EmailBcc"]))
                {
                    // Set the Bcc address of the mail message
                    mMailMessage.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EmailBcc"]));
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EmailCc"])) // Check if the Cc value is null or an empty value
                {
                    // Set the CC address of the mail message
                    mMailMessage.CC.Add(ConfigurationManager.AppSettings["EmailCc"]);
                }

                mMailMessage.Subject = ConfigurationManager.AppSettings["EmailSubject"]; // Set the subject of the mail message
                mMailMessage.Body = theNotification; // Set the body of the mail message
                mMailMessage.IsBodyHtml = true; // Set the format of the mail message body as HTML
                mMailMessage.Priority = MailPriority.Normal; // Set the priority of the mail message to normal

                var mSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServerID"]); // Instantiate a new instance of SmtpClient

                mSmtpClient.Send(mMailMessage); // Send the mail message

                mMailMessage.Dispose();
            }
            catch (Exception)
            {
                // Handle exception (optional: log the error)
            }
        }
    }
}