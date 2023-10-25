namespace Zion1.Notification.Domain.Entities
{
    public class EmailSettings
    {
        public string Server { get; set; } = string.Empty;
        public int Port { get; set; }
        public string FromEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
