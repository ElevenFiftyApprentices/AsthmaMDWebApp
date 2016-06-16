using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsthmaMDWebApp.Data
{
    public class AlertEntity
    {
        [Key]
        public int AlertId { get; set; }

        public int ChildId { get; set; }

        public string Mdeicine { get; set; }

        [Display(Name ="Start Time")]
        public DateTimeOffset AlertStartTime { get; set; }

        [Display(Name ="Start Date")]
        public DateTimeOffset AlertStartDate { get; set; }

        [Display(Name ="End Time")]
        public DateTimeOffset AlertEndTime { get; set; }

        [Display(Name ="End Date")]
        public DateTimeOffset AlertEndDate { get; set; }

        [Display(Name ="Alert Name")]
        public string AlertName { get; set; }

        public uint Frequency { get; set; }

        public ChildEntity Child { get; set; }
    }
}