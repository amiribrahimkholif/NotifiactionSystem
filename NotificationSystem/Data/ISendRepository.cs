using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Data
{
    interface ISendRepository
    {
        //Sent Notification Queuing actually
        public bool SendViaEmail(String Name, int NotificationId, String email);
        public bool SendViaSMS(int NotificationId , String phone ,String Name );
        
    }
}
