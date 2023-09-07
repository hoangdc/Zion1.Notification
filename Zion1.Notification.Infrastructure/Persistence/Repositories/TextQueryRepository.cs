using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Infrastructure.Persistence.Repositories
{
    public class TextQueryRepository : QueryRepository<Text>, ITextQueryRepository
    {
        private NotificationDbContext _notificationDbContext;
        public TextQueryRepository(NotificationDbContext notificationDbContext) : base(notificationDbContext)
        {
            _notificationDbContext = notificationDbContext;
        }
    }
}
