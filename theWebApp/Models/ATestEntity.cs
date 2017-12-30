using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace theWebApp.Models
{
    public class ATestEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class ATestEntityDBContext : DbContext
    {
        public DbSet<ATestEntity> entities { get; set; }
    }
}