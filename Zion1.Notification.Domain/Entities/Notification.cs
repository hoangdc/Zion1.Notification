using Zion1.Common.Domain.Entities;

namespace Zion1.Notification.Domain.Entities
{
    public class Notification : EntityBase<int>
    {
        public string Message { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
    }
}
