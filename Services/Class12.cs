using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class Class12
    {
        public void send(String pass,String Email)
        {
           


            Execute(pass, Email).Wait();
        }

         static async Task Execute(String pass,String email)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            if (apiKey == null)
            {
                Environment.SetEnvironmentVariable("SENDGRID_API_KEY", "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");

                apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            }
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("dibyajyotijena2015@gmail.com", "Dibya Jyoti");
            var subject = "Password";
            var to = new EmailAddress(email, "client");
            var plainTextContent = "Your password";
            String dest = "http://localhost:4200/password_mgr/" + pass;
            var htmlContent = "<strong>Your Login Password Link is:  </strong></br><a href="+dest+">"+pass+"</a>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
