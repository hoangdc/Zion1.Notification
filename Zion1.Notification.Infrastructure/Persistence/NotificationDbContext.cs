using Microsoft.EntityFrameworkCore;

namespace Zion1.Notification.Infrastructure.Persistence
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Email> Emails { get; set; }
        public DbSet<Domain.Entities.Text> Texts { get; set; }

    }
}
