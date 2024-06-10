using System.Net;
using System.Net.Mail;
using UnityEngine;

public static class SimpleGmailSender
{
    public static void SendEmail(string recipientEmail, string subject, string body)
    {
        string senderEmail = "handayinformation@gmail.com";
        string senderPassword = "nqms qyoc keml ufab";

        try
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(senderEmail);
            recipientEmail = recipientEmail.Replace("\u200B", "");
            msg.To.Add(recipientEmail);
            msg.Subject = subject;
            msg.Body = body;

            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntcd = new NetworkCredential();
            ntcd.UserName = senderEmail;
            ntcd.Password = senderPassword;
            smt.Credentials = ntcd;
            smt.EnableSsl = true;
            smt.Port = 587;
            smt.Send(msg);
            Debug.Log("Email sent successfully!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error sending email: " + e.Message);
        }
    }
}
