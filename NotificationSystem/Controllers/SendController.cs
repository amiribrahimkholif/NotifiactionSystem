using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private AppDbContext _context1;
        public SendController(AppDbContext context)
        {
            Notification n = new Notification();
            _context1 = context;

            if (!_context1.EmailQueue.Any())
            {
                _context1.SaveChanges();
            }
        }
        // GET: api/<Controller>
        [HttpGet]
        public IEnumerable<EmailQueue> GetEmailQueue()
        {
            return _context1.EmailQueue;
        }
        // POST api/<Controller>
        [HttpPost]
        public IActionResult SendViaEmail(String personName,int NotificationId,[FromBody] EmailQueue em )
        {
            EmailQueue e = new EmailQueue {
                EmailAddress = em.EmailAddress,
                NotificationContent ="Dear, "+personName+ _context1.Notifications.Find(NotificationId).Content,
            };
            _context1.EmailQueue.Add(e);
            _context1.SaveChanges();

            return Ok();
        }
        // POST api/<Controller>
        [HttpPost]
        public IActionResult SendViaSMS(String personName, int NotificationId, [FromBody] SMSQueue sm)
        {
            SMSQueue s = new SMSQueue
            {
                PhoneNumber=sm.PhoneNumber,
                NotificationContent = "Dear," + personName + _context1.Notifications.Find(NotificationId).Content,
            };
            _context1.SmsQueue.Add(s);
            _context1.SaveChanges();

            return Ok();
        }

    }
}
