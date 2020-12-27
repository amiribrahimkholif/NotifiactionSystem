using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Models
{
    public class SMSQueue
    {
        public int Id { get; set; }
        public String phoneNumber { get; set; }
        public String NotificationContent { get; set; }

    }
}
