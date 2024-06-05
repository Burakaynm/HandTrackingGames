using System.Net;
using System.Net.Mail;
using UnityEngine;

public static class SimpleGmailSender
{
    public static void SendEmail(string recipientEmail, string subject, string body)
    {
        string senderEmail = "test.elin.oglu@gmail.com";
        string senderPassword = "cqgu tkgh pgnn nzjo\r\n";

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = subject;
            mail.Body = body;

            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential(senderEmail, senderPassword) as ICredentialsByHost;
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);
            Debug.Log("Email sent successfully!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error sending email: " + e.Message);
        }
    }
}
