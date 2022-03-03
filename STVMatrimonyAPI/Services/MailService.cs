using STVMatrimonyAPI.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimonyAPI.Model;
using System.Net.Mail;

namespace STVMatrimonyAPI.Services
{
    public class MailService : IMailService
    {
        private readonly IOptions<Model.EMailConfiguration> _emailConfiguration;
        public MailService(IOptions<Model.EMailConfiguration> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public async Task<bool> SendRegisterEmailAsync(MailRequest mailRequest)
        {
            return await SendEmailAsync(mailRequest);
        }
        public async Task<bool> SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_emailConfiguration.Value.Mail);
                    mail.To.Add(new MailAddress(mailRequest.ToEmail));
                    mail.Subject = mailRequest.Subject;
                    mail.Body = mailRequest.Body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(_emailConfiguration.Value.Host, _emailConfiguration.Value.Port))
                    {
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = new System.Net.NetworkCredential(_emailConfiguration.Value.Mail, _emailConfiguration.Value.Password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                await Task.Delay(1);

                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
