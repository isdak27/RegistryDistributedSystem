using AuthenticationWebAPI.Models;
using System.Net;
using System.Net.Mail;

namespace AuthenticationWebAPI.Controllers
{
    public class EnvioCorreos
    {
        private   HttpClient _httpClient;
        private   string host_smptp;
        private   string email_smpt = "your_email@example.com";
        private   string password_smpt =  "your_password";

        public void SendEmail(EmailNotification notification)
        {
            {
                try
                {
                    // Set up the SMTP client
                    //credential info SMTP
                    SmtpClient client = new SmtpClient(this.host_smptp, 587);
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(this.email_smpt , this.password_smpt);

                    // Create a new email message
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(notification.from );
                    message.To.Add(notification.to);
                    message.Subject = notification.subject;

                    message.Body = notification.body;

                    // Send the email
                    client.Send(message);

                    Console.WriteLine("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending email: " + ex.Message);
                }
            }
        }
    }

    public string CreateBody(User user)
    {


        return "";

    }
}
