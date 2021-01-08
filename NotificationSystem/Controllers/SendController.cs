using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Models;
using System;
using NotificationSystem.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private ISendRepository _SendRepository;
        public SendController(AppDbContext con)
        {
            _SendRepository = new SendRepo(con);
            
        }
        // POST api/<Controller>
        [HttpPost]
        public bool SendViaEmail(String Name,  int NotificationId,  String email,String y ="") 
        {
           return _SendRepository.SendViaEmail(Name,NotificationId,email,y);
        }
        // POST api/<Controller>
        [HttpPost]
        public bool SendViaSMS(int NotificationId, string phone, string Name, String y="")
        {
            return _SendRepository.SendViaSMS(NotificationId, phone, Name,y);
        }

    }
}
