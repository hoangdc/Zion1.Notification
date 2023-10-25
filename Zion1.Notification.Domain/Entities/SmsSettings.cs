namespace Zion1.Notification.Domain.Entities
{
    public class SmsSettings
    {
        public string AccountId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string FromPhoneNumber { get; set; } = string.Empty;
    }
}
