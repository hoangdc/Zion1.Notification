using Zion1.Common.Domain.Entities;

namespace Zion1.Notification.Domain.Entities
{
    public class Notification : BaseEntity<int>
    {
        public string Message { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
