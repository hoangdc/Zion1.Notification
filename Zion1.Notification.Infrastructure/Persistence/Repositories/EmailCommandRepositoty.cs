using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Infrastructure.Persistence.Repositories
{
    public class EmailCommandRepository : CommandRepository<Email>, IEmailCommandRepository
    {
        private readonly IConfiguration _config;
        public EmailCommandRepository(IConfiguration configuration, NotificationDbContext notificationDbContext) : base(notificationDbContext)
        {
            _config = configuration;
        }

        public async Task<int> SaveEmailAsync(Email item)
        {
            var notification = await AddAsync(item);
            return notification.Id;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            bool isSuccess = true;
            await Task.Run(() =>
            {
                var emailSettings = _config.GetSection("EmailSettings").Get<EmailSettings>();
                if (emailSettings == null) 
                {
                    isSuccess = false;
                }
                else
                {
                    //create email message
                    if (string.IsNullOrEmpty(email.From))
                        email.From = emailSettings.FromEmail;

                    var emailMessage = new MimeMessage();
                    emailMessage.From.Add(MailboxAddress.Parse(email.From));
                    emailMessage.To.Add(MailboxAddress.Parse(email.To));
                    emailMessage.Subject = email.Subject;
                    emailMessage.Body = new TextPart(TextFormat.Html) { Text = email.Message };

                    //send email
                    using var smtp = new SmtpClient();
                    smtp.Connect(emailSettings.Server, emailSettings.Port, SecureSocketOptions.StartTls);
                    smtp.Authenticate(emailSettings.UserName, emailSettings.Password);
                    smtp.Send(emailMessage);
                    smtp.Disconnect(true);
                }
            });

            return isSuccess;
        }

        
    }
}
