using Zion1.Common.Application.Contracts;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Application.Repositories
{
    public interface IEmailCommandRepository : ICommandRepository<Email>
    {
        Task<int> SaveEmailAsync(Email email);
        Task<bool> SendEmailAsync(Email email);
    }
}
