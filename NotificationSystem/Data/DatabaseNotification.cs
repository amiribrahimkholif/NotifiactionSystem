using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Data
{

    public class DatabaseNotification : INotificationRepository
    {
        private AppDbContext _context;

        public DatabaseNotification(AppDbContext context)
        {
            _context = context;
        }
        
        public void DequeuingEmailQueue()
        {
            List<EmailQueue> listEmail = _context.EmailQueue.ToList();
            for(int i=0;i<listEmail.Count;i++)
            {
                if (listEmail[i].isSent == true)
                    Console.WriteLine(listEmail[i].NotificationContent+"    "+listEmail[i].EmailAddress);
            }
            Console.WriteLine("\n");
        }
        public void DequeuingSMSQueue()
        {
            List<SMSQueue> listSMS = _context.SmsQueue.ToList();
            for (int i = 0; i < listSMS.Count; i++)
            {
                if (listSMS[i].isSent == true)
                    Console.WriteLine(listSMS[i].NotificationContent + "    " + listSMS[i].PhoneNumber);
            }
            Console.WriteLine("\n");
        }
        public bool AddNotification([FromBody] Notification notification)
        {
            if (notification == null)
                return false;

            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteNotificatonByID(int id)
        {
            var notification = _context.Notifications.FirstOrDefault(i => i.Id == id);
            if (notification == null)
                return false;

            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            return true;
        }

        public Notification GetNotificationById(int id)
        {
            var notification = _context.Notifications.FirstOrDefault(i => i.Id == id);
            if (notification == null)
                return null;

            return notification;
        }

        public IEnumerable<Notification> GetNotifications()
        {
            return _context.Notifications;
        }

        public bool UpdateNotificationByID(int id, [FromBody] Notification no)
        {
            if (no == null || no.Id != id)
                return false;

            var notification = _context.Notifications.FirstOrDefault(i => i.Id == id);
            if (notification == null)
                return false;

            notification.Content = no.Content;

            _context.Notifications.Update(notification);
            _context.SaveChanges();
            return true;
        }
    }
}