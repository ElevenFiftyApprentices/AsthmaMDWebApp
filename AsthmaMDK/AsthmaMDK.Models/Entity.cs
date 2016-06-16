using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsthmaMDK.Models
{
    public class Entity
    {
        [Key]
        public int EntityId { get; set; }
        [Display(Name ="Name")]
        public string ChildName { get; set; }
        [Display(Name ="Frequency Reminder")]
        [DefaultValue(1)]
        public int Frequency { get; set; }
        [Display(Name ="Peak Flow Meter Reading")]
        public int PFMReading { get; set; }
        [Display(Name ="How are you feeling?")]
        public int FeelingScore { get; set; }
        [Display(Name = "Have an attack?")]
        public bool Attack { get; set; }
    }
}
