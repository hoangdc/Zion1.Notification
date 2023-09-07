using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Infrastructure.Persistence.Repositories
{
    public class TextCommandRepository : CommandRepository<Text>, ITextCommandRepository
    {
        private NotificationDbContext _notificationDbContext;
        public TextCommandRepository(NotificationDbContext notificationDbContext) : base(notificationDbContext)
        {
            _notificationDbContext = notificationDbContext;
        }

        public async Task<bool> SendAsync(Text item)
        {
            //Store Database
            var notification = await AddAsync(item);
            //Send message out
            bool result = await SendSMS(item);
            return result;
        }

        private async Task<bool> SendSMS(Text text)
        {
            return true;
        }
    }
}
