namespace Zion1.Notification.Application.Repositories
{
    public interface INotificationRepository<T> where T : class
    {
        Task<int> SendAsync(T item); 
    }
}
