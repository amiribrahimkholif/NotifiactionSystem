using System;

namespace NotificationSystem
{
    public class Notification
    {
        public int? Id  { get; set; }
        public String Name { get; set; }
        public String Content { get; set; }

        public enum Languages { Arabic , English}

    }
}
