namespace Zion1.Notification.Domain.Entities
{
    public class SMTPSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
