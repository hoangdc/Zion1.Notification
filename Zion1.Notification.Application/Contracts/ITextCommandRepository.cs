using Zion1.Common.Application.Contracts;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Application.Repositories
{
    public interface ITextCommandRepository : ICommandRepository<Text>
    {
        Task<int> SaveTextAsync(Text text);
        Task<bool> SendTextAsync(Text text);
    }
}
