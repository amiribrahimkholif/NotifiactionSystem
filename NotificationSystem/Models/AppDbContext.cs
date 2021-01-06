using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        public AppDbContext()
        {
                
        }
        public DbSet<Notification> Notifications { set;  get; }
        public DbSet<EmailQueue> EmailQueue { set; get; }
        public DbSet<SMSQueue> SmsQueue { set; get; }

    }
}
