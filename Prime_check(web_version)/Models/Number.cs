using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prime_check_web_version_.Models
{
    public class Number
    {
        [Required]
        [Display(Name ="Your number")]
        public long n { get; set; }
        public bool IsPrime { get; set; }
    }
}
