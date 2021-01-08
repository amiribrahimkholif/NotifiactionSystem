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
        public SendRepo (AppDbContext context)
        {
            _context1 = context;
        }
        public bool SendViaEmail(string Name, int NotificationId, string Email,String y ="")
        {
            String temp;
            if (_context1.Notifications.Find(NotificationId) == null)
                return false;
            else
            {
                temp = _context1.Notifications.Find(NotificationId).Content;
                temp = SendRepo.ReplacePlaceholders(temp, Name,y);
            }
           
            EmailQueue e = new EmailQueue
            {
                EmailAddress = Email,
                NotificationContent = temp,
            };
            _context1.EmailQueue.Add(e);
            _context1.SaveChanges();

            return true;
        }
        public bool SendViaSMS(int NotificationId, string phone, string Name,String y)
        {
            String temp;
            if (_context1.Notifications.Find(NotificationId) == null)
                return false;
            else
            {
                temp = _context1.Notifications.Find(NotificationId).Content;
                temp=SendRepo.ReplacePlaceholders(temp,Name,y);              
            }
            SMSQueue s = new SMSQueue
            {
                PhoneNumber = phone,
                NotificationContent =temp,
            };
            _context1.SmsQueue.Add(s);
            _context1.SaveChanges();

            return true;
        }
        
        public static String ReplacePlaceholders(String content, String name,String y="")
        { 
                String temp = content.Replace("{x}", name);
                return temp.Replace("{y}", y);
               
        }
    }
}

