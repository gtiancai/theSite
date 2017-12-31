using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace theWebApp.Modes
{
    public class ATestEntity
    {
        [Display]
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date")]
        public DateTime DateTime { get; set; }
    }

    public class ATestEntityDBContext : DbContext
    {
        public DbSet<ATestEntity> entities { get; set; }
    }
}