using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private AppDbContext _context1;
        public SendController(AppDbContext context)
        {
            _context1 = context;
            if (!_context1.EmailQueue.Any())
            {
                _context1.EmailQueue.Add(new EmailQueue
                { Id = 1, NotificationContent = "Confirm  Your Email", EmailAddress = "amir@yahoo.com" });
                _context1.EmailQueue.Add(new EmailQueue
                { Id = 2, NotificationContent = "Confirm  Your Email", EmailAddress = "amir@yahoo.com" });
                _context1.EmailQueue.Add(new EmailQueue
                { Id = 3, NotificationContent = "Confirm  Your Email", EmailAddress = "amir@yahoo.com" });
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
        public IActionResult SendViaEmail([FromBody] EmailQueue e)
        {
            if (e == null)
                return BadRequest();
            
            _context1.EmailQueue.Add(e);
            _context1.SaveChanges();

            return Ok();
        }
        // POST api/<Controller>
        [HttpPost]
        public IActionResult SendViaSMS([FromBody] SMSQueue s)
        {
            if (s == null)
                return BadRequest();
            _context1.SmsQueue.Add(s);
            _context1.SaveChanges();

            return Ok();
        }

    }
}
