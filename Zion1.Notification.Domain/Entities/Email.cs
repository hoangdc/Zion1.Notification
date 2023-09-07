using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion1.Notification.Domain.Entities
{
    public class Email : Notification
    {
        public string Subject { get; set; }
        
        //public List<IFormFile> Attachments { get; set; }
    }
}
