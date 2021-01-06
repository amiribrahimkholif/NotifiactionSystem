using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using NotificationSystem.Data;
using System.Threading.Tasks;


namespace NotificationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationConteroller : ControllerBase
    {
        private INotificationRepository _NotificationRepository;
        public NotificationConteroller()
        {
           _NotificationRepository =new  DatabaseNotification ();
            
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Notification> GetNotifications()
        {
            return _NotificationRepository.GetNotifications();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetNotificationById")]
        public ActionResult <Notification> GetNotificationById(int id)
        {
            return _NotificationRepository.GetNotificationById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool AddNotification([FromBody]Notification notification)
        {

            return _NotificationRepository.AddNotification(notification);
        }
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool UpdateWorkshopByID(int id, [FromBody] Notification no)
        {
            return _NotificationRepository.UpdateNotificationByID(id,no);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool DeleteNotificatonByID(int id)
        {
            return _NotificationRepository.DeleteNotificatonByID(id);
        }
    }
}
