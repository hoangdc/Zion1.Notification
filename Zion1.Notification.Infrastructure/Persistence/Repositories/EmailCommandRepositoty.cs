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

        public async Task<int> SendAsync(Email item)
        {
            //Send message out
            await SendEmail(item);
            //Store Database
            var notification = await AddAsync(item);
            return notification.Id;
        }

        private async Task SendEmail(Email email)
        {
            await Task.Run(() =>
            {
                // create email message
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(MailboxAddress.Parse(email.From));
                emailMessage.To.Add(MailboxAddress.Parse(email.To));
                emailMessage.Subject = email.Subject;
                emailMessage.Body = new TextPart(TextFormat.Html) { Text = email.Message };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("hoangdc@gmail.com", "azccpzuxiyowejtr");
                smtp.Send(emailMessage);
                smtp.Disconnect(true);

            });
            
        }
    }
}
