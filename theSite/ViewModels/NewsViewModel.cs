using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theSite.ViewModels
{
    public class NewsViewModel
    {
        [Display(Name = "No.")]
        public long ID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }

        /*
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }

        public virtual User User { get; set; }
        */
    }
}