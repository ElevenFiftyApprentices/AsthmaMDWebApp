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

        public string Medicine { get; set; }
        
        public DateTimeOffset AlertStartTime { get; set; }

        public DateTimeOffset AlertStartDate { get; set; }

        public DateTimeOffset AlertEndTime { get; set; }

        public DateTimeOffset AlertEndDate { get; set; }

        public string AlertName { get; set; }

        public uint Frequency { get; set; }
    }
}