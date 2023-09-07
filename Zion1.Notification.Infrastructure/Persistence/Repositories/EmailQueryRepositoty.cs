using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Infrastructure.Persistence.Repositories
{
    public class EmailQueryRepository : QueryRepository<Email>, IEmailQueryRepository
    {
        private NotificationDbContext _notificationDbContext;
        public EmailQueryRepository(NotificationDbContext notificationDbContext) : base(notificationDbContext)
        {
            _notificationDbContext = notificationDbContext;
        }

        
    }
}
