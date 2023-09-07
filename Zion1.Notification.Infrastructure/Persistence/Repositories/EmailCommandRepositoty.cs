using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Infrastructure.Persistence.Repositories
{
    public class EmailCommandRepository : CommandRepository<Email>, IEmailCommandRepository
    {
        private NotificationDbContext _notificationDbContext;
        public EmailCommandRepository(NotificationDbContext notificationDbContext) : base(notificationDbContext)
        {
            _notificationDbContext = notificationDbContext;
        }

        public async Task<bool> SendAsync(Email item)
        {
            //Store Database
            var notification = await AddAsync(item);
            //Send message out
            bool result = await SendEmail(item);
            return result;
        }

        private async Task<bool> SendEmail(Email email)
        {
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("hoangdc@gmail.com", "jnmjjdtypjgkniln");

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(email.From));
            message.To.Add(MailboxAddress.Parse(email.To));
            message.Subject = email.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = email.Message
            };

            // send email
            smtp.Send(message);
            smtp.Disconnect(true);

            return true;
        }
    }
}
