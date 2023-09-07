namespace Zion1.Notification.Application.Repositories
{
    public interface INotificationRepository<T> where T : class
    {
        Task<bool> SendAsync(T item); 
    }
}
