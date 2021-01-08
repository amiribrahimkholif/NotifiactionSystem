using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Data
{
    public class SendEmailNotification : INotificationGateway
    {
        
        public void SendNotification(int NotificationID)
        {
            Random rnd = new Random();
            int x = rnd.Next(1);
            throw new NotImplementedException();
        }
    }
}
