using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Data
{
    interface INotificationRepository
    {
        //CRUD operations for notification tempelate
        public IEnumerable<Notification> GetNotifications();
        public Notification GetNotificationById(int id);
        public bool AddNotification([FromBody] Notification notification);
        public bool UpdateNotificationByID(int id, [FromBody] Notification no);
        public bool DeleteNotificatonByID(int id);
        public void DequeuingEmailQueue();
        public void DequeuingSMSQueue();


    }
}
