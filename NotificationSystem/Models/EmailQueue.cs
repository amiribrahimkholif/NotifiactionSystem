using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Models
{
    public class EmailQueue
    {   
        public  int Id { get; set; }
        public String EmailAddress { get; set; }
        public String NotificationContent { get; set; }
        public bool isSent { get; set; }

    }

}
