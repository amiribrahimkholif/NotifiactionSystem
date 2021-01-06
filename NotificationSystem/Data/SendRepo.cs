using System;
using System.Collections.Generic;
using System.Linq;
using NotificationSystem.Models;
using System.Threading.Tasks;

namespace NotificationSystem.Data
{
    public class SendRepo : ISendRepository
    {
        private AppDbContext _context1;
        public bool SendViaEmail(string Name, int NotificationId, string Email)
        {
            EmailQueue e = new EmailQueue
            {
                EmailAddress = Email,
                NotificationContent = _context1.Notifications.Find(NotificationId).Content,
            };
            _context1.EmailQueue.Add(e);
            _context1.SaveChanges();

            return true;
        }
        public bool SendViaSMS(int NotificationId, string phone, string Name)
        {
            SMSQueue s = new SMSQueue
            {
                PhoneNumber = phone,
                NotificationContent = _context1.Notifications.Find(NotificationId).Content,
            };
            _context1.SmsQueue.Add(s);
            _context1.SaveChanges();

            return true;
        }
        public String ReplacePlaceholders(int notificationId ,String name)
        {
            if (_context1.Notifications.Find(notificationId) == null)
                return null;
            else
            {
                String temp = _context1.Notifications.Find(notificationId).Content;
                temp.Replace("{x}", name);
                return temp;
            }
            
        }

        public String ReplacePlaceholders(int notificationId, String name,String y)
        {
            if (_context1.Notifications.Find(notificationId) == null)
                return null;
            else
            {
                String temp = _context1.Notifications.Find(notificationId).Content;
                temp.Replace("{x}", name);
                temp.Replace("{y}", y);
                return temp;
            }

        }
    }
}

