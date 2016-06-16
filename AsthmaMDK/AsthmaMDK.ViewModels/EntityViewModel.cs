using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsthmaMDK.ViewModels
{
    public class EntityViewModel
    {
        
        public int EntityId { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "Please enter 2 characters.")]
        public string ChildName { get; set; }
        public int Frequency { get; set; }
        [Required]
        public int PFMReading { get; set; }
        [Required]
        public int FeelingScore { get; set; }
        [Required]
        public bool Attack { get; set; }
    }
}
