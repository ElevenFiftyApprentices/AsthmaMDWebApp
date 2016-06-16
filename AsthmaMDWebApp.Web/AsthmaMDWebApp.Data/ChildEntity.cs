using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsthmaMDWebApp.Data
{
    public class ChildEntity
    {
        [Key]
        public int ChildId { get; set; }

        public Guid UserId { get; set; }

        public string ChildName { get; set; }

        public int ChildAge { get; set; }

        public float ChildHeight { get; set; }

        public int ChildPeakFlowMeter { get; set; }

        public float ChildFEV1 { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        public ICollection<LogEntity> Logs { get; set; }

        public ICollection<AlertEntity> Alerts { get; set; }

        public GenderType Gender { get; set; }

        public enum GenderType
        {
            Male = 1,
            Female = 2,
            Other = 3
        }
    }
}