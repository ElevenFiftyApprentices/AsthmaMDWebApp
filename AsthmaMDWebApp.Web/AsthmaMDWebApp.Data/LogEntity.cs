using System;
using System.ComponentModel.DataAnnotations;

namespace AsthmaMDWebApp.Data
{
    public class LogEntity
    {
        [Key]
        public int LogId { get; set; }

        public int ChildId { get; set; }

        [Display(Name ="Log Date")]
        public DateTimeOffset LogDate { get; set; }

        [Display(Name ="Peak Flow Meter")]
        public int LogPeakFlowMeter { get; set; }

        [Display(Name ="FEV-1")]
        public float LogFAV1 { get; set; }

        public string Symptoms { get; set; }
        
        public string Triggers { get; set; }

        public string Medication { get; set; }

        [Display(Name ="Severity on a scale of One to Ten.")]
        [Range(1, 10)]
        public int SeverityLevel { get; set; }

        public ChildEntity Child { get; set; }
    }
}