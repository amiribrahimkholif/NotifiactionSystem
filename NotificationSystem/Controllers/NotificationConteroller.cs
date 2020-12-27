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
    public class NotificationConteroller : ControllerBase
    {
        private AppDbContext _context;
        public NotificationConteroller(AppDbContext context)
        {
            _context = context;
            _context = context;
            if (!_context.Notifications.Any())
            {
                _context.Notifications.Add(new Notification
                { Id = 1, Content = "Confirm  Your Email", Type = "confirmation Email" });
                _context.Notifications.Add(new Notification
                { Id = 2, Content = "forget  Your Email Password", Type = "Forgetten email" });
                _context.Notifications.Add(new Notification
                { Id = 3, Content = "Booking an item", Type = " Booking Confirmation" });
                _context.SaveChanges();
            }
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Notification> GetNotifications()
        {
            return _context.Notifications;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <Notification> GetNotificationById(int id)
        {
            var notification = _context.Notifications.FirstOrDefault(i => i.Id == id);
            if (notification == null)
                return NotFound();

            return notification;
            //_context1.SaveChanges();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult AddNotification([FromBody]Notification notification)
        {
            if (notification == null)
                return BadRequest();

            _context.Notifications.Add(notification);
            _context.SaveChanges();

            return CreatedAtRoute("GetNotifications", new { id =notification.Id }, notification);
        }
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateWorkshopByID(int id, [FromBody] Notification no)
        {

            if (no == null || no.Id != id)
                return BadRequest();

            var notification = _context.Notifications.FirstOrDefault(i => i.Id == id);
            if (notification == null)
                return NotFound();

            notification.Content = no.Content;
            notification.Type = no.Type;

            _context.Notifications.Update(notification);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNotificatonByID(int id)
        {
            var notification = _context.Notifications.FirstOrDefault(i => i.Id == id);
            if (notification == null)
                return NotFound();

            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
