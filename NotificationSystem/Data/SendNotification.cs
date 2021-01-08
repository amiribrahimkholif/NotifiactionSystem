using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Data
{
    public class SendNotification : INotificationGateway
    {
        public bool Send(int NotificationID)
        {
            Random rnd = new Random();
            int x = rnd.Next(2);
            if(x==0)
            {
                return false;
            }else
            {
                return true;
            }
            
        }
    }
}
