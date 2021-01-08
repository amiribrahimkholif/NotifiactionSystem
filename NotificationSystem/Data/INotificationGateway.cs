using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Data
{
    interface INotificationGateway
    {
        public bool Send(int NotificationID);
    }
}
